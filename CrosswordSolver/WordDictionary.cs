using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    static class WordDictionary
    {
        public List<string> dictionary_words { get; set; }

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
            dictionary_words = new List<string>();
            string word;
            
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((word = file.ReadLine()) != null)
            {
                dictionary_words.Add(word);
            }
            file.Close();
        }
    }
}
