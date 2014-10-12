using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class WordDictionary
    {
        private List<string> dictionaryWords { get; set; }

        /// <summary>
        /// MDictionary Constructor
        /// </summary>
        public WordDictionary()
        {
        }

        /// <summary>
        /// Loads lines (assumed to be words) from 
        /// a text file into a list of type String
        /// </summary>
        /// <param name="filePath">Path of text file</param>
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

        /// <summary>
        /// Loads lines (assumed to be words) from 
        /// a text file into a list of type String
        /// </summary>
        /// <param name="filePath">Path of text file</param>
        public List<string> getAllWords()
        {
            return dictionaryWords;
        }

        /// <summary>
        /// Loads lines (assumed to be words) from 
        /// a text file into a list of type String
        /// </summary>
        /// <param name="filePath">Path of text file</param>
        public WordResultSet getWordsWithSize(int size)
        {
            WordResultSet wordSet = new WordResultSet();

            foreach (var word in dictionaryWords)
            {
                if (word.Length == size)
                {
                    wordSet.AddNew(word);
                }
            }

            wordSet.SetWordSize(size);
            return wordSet;
        }
    }
}
