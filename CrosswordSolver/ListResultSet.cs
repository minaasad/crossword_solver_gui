using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class ListResultSet
    {
        private List<WordResultSet> resultSets { get; set; }

        public ListResultSet()
        {
            resultSets = new List<WordResultSet>();
        }

        public void AddNew(WordResultSet resultSet)
        {
            resultSets.Add(resultSet);
        }

        public List<WordResultSet> GetAllSets()
        {
            return resultSets;
        }

        public int GetCount()
        {
            return resultSets.Count;
        }

        public int GetAllSizesMultiplied()
        {
            int size = 0;
            foreach (WordResultSet var in resultSets)
            {
                if (size == 0) size = var.GetAllWords().Count;
                else size *= var.GetAllWords().Count;
            }
            return Math.Abs(size);
        }
    }
}
