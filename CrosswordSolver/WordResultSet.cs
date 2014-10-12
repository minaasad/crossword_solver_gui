using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class WordResultSet
    {
        List<string> wordSet {get; set;}
        int size;

        public WordResultSet()
        {
            wordSet = new List<string>();
        }

        public void SetWordSize(int iSize)
        {
            size = iSize;
        }

        public int GetWordSize()
        {
            return size;
        }

        public int GetCount()
        {
            return wordSet.Count;
        }

        public void AddNew(string word)
        {
            wordSet.Add(word);
        }

        public List<string> GetAllWords()
        {
            return wordSet;
        }
    }
}
