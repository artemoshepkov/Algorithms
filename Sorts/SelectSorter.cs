using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    public static class SelectSorter
    {
        public static Tuple<int, int> Sort<T>(T[] array) where T : IComparable
        {
            int comparisonsNumber = 0;
            int assignmentsNumber = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                int indexMinNumber = i;
                assignmentsNumber++;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[indexMinNumber]) < 0)
                    {
                        indexMinNumber = j;
                        assignmentsNumber++;
                    }
                    comparisonsNumber++;
                }
                (array[indexMinNumber], array[i]) = (array[i], array[indexMinNumber]);
                assignmentsNumber += 3;
            }

            return Tuple.Create(comparisonsNumber, assignmentsNumber);
        }
    }
}
