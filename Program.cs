using Algorithms.ConsoleOutput;
using Algorithms.Sorts;

namespace Algorithms
{
    public class Program
    {

        private static void Main()
        {
            int[][] arrays =
            {
                new int[] { 0 },
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 5, 4, 3, 2, 1 },
                RandomGenerator.GenerateArray(10, 0, 100)
            };

            //SortVerify.Verify(arrays, MergeSorter.Sort);
            SortsUI.Start(MergeSorter.Sort);
        }
    }
}