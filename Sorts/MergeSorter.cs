using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorts
{
    public class MergeSorter
    {
        public static Tuple<int, int> Sort<T>(T[] array) where T : IComparable
        {
            var operationNumber = new Tuple<int, int>(0, 0);

            int pairLen = 1;
            while (pairLen < array.Length)
            {
                int i = 0;
                while (i < array.Length)
                {
                    int left1 = i;
                    int right1 = i + pairLen - 1;
                    int left2 = i + pairLen;
                    int right2 = i + 2 * pairLen - 1;

                    if (left2 >= array.Length)
                        break;

                    if (right2 >= array.Length)
                        right2 = array.Length - 1;

                    var temp = Merge(array, left1, right1, left2, right2);
                    for (int j = 0; j < right2 - left1 + 1; j++)
                        array[i + j] = temp[j];

                    i += 2 * pairLen;
                }
                array.Print();
                Console.WriteLine();
                pairLen *= 2;
            }

            return operationNumber;
        }

        private static T[] Merge<T>(T[] array, int left1, int right1, int left2, int right2) where T : IComparable
        {
            int comparisonsNumber = 0;
            int assignmentsNumber = 0;

            var temp = new List<T>();

            while (left1 <= right1 && left2 <= right2)
            {
                if (array[left1].CompareTo(array[left2]) <= 0)
                {
                    temp.Add(array[left1]);
                    left1++;
                }
                else
                {
                    temp.Add(array[left2]);
                    left2++;
                }
            }

            while (left1 <= right1)
            {
                temp.Add(array[left1]);
                left1++;
            }

            while (left2 <= right2)
            {
                temp.Add(array[left2]);
                left2++;
            }

            //return Tuple.Create(comparisonsNumber, assignmentsNumber);
            return temp.ToArray();
        }
    }
}
