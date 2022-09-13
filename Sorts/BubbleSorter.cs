using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    public static class BubbleSorter
    {
        public static Tuple<int, int> Sort<T>(T[] array) where T : IComparable
        {
            int comparisonsNumber = 0;
            int assignmentsNumber = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        assignmentsNumber += 3;
                    }
                    comparisonsNumber++;
                }
            }

            return Tuple.Create(comparisonsNumber, assignmentsNumber);
        }
    }
}
