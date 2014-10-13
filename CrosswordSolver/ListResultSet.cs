using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class ListResultSet
    {
        public List<WordResultSet> allWordResultSets { get; set; }

        public ListResultSet()
        {
            allWordResultSets = new List<WordResultSet>();
        }

        public void AddNew(WordResultSet resultSet)
        {
            allWordResultSets.Add(resultSet);
        }

        public int GetCount()
        {
            return allWordResultSets.Count;
        }

        public int GetAllSizesMultiplied()
        {
            int size = 0;
            foreach (WordResultSet var in allWordResultSets)
            {
                if (size == 0) size = var.wordSet.Count;
                else size *= var.wordSet.Count;
            }
            return Math.Abs(size);
        }
    }
}
