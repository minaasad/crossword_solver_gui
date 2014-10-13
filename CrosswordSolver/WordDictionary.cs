using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class WordDictionary
    {
        public List<string> dictionaryWords { get; set; }

        public WordDictionary()
        {
        }

        public void LoadFromFile(string filePath)
        {
            dictionaryWords = new List<string>();
            string word;
            
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((word = file.ReadLine()) != null)
            {
                dictionaryWords.Add(word);
            }
            file.Close();
        }

        public WordResultSet getWordsWithSize(int size)
        {
            WordResultSet wordSet = new WordResultSet(size);

            foreach (var word in dictionaryWords)
            {
                if (word.Length == size)
                {
                    wordSet.AddNew(word);
                }
            }
            return wordSet;
        }
    }
}
