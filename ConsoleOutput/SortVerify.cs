using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ConsoleOutput
{
    public static class SortVerify
    {
        public static void Verify<T>(T[][] array, Func<T[], Tuple<int, int>> sort)
        {
            for (int i = 0; i < array.Length; i++)
                PrintSorting(array[i], sort);
        }

        public static void PrintSorting<T>(T[] array, Func<T[], Tuple<int, int>> sort)
        {
            array.Print();
            Console.Write("- ");
            var operationNumber = sort(array);

            array.Print();
            Console.WriteLine("\nComparisons = {0}\nAssigments = {1}\nTotal = {2}", 
                operationNumber.Item1, 
                operationNumber.Item2, 
                operationNumber.Item1 + operationNumber.Item2);
            Console.WriteLine();
        }
    }
}
