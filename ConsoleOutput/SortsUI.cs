using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ConsoleOutput
{
    public static class SortsUI
    {
        public static void Start(Func<int[], Tuple<int, int>> sort)
        {
            int arraySize = int.Parse(Console.ReadLine());
            var array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
                array[i] = int.Parse(Console.ReadLine());

            SortVerify.PrintSorting(array, sort);
        }
    }
}
