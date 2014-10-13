using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class WordResultSet
    {
        public List<string> wordSet {get; set;}
        public int size;

        public WordResultSet()
        {
            wordSet = new List<string>();
        }

        public WordResultSet(int iSize)
        {
            wordSet = new List<string>();
            size = iSize;
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
    }
}
