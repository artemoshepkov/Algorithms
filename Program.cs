using Algorithms.ConsoleOutput;
using Algorithms.DFT;
using Algorithms.Multiply;
using Algorithms.Sorts;
using System.Numerics;

namespace Algorithms
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine(ColumnMultiplication.Multiply(123, 123));
            Console.WriteLine(ColumnMultiplication.Multiply(11, 11));
            Console.WriteLine(ColumnMultiplication.Multiply(12, 12));
            Console.WriteLine(ColumnMultiplication.Multiply(123, 10000));

            Console.WriteLine(FastMultiplication.Multiply(12, 50));
            Console.WriteLine(FastMultiplication.Multiply(123, 1000));
            Console.WriteLine(FastMultiplication.Multiply(11, 11));
            Console.WriteLine(FastMultiplication.Multiply(12, 0));
            Console.WriteLine(FastMultiplication.Multiply(0, 0));
        }

        private static double[] GetArrayFunc(Func<double, double> func, int number)
        {
            var result = new double[number];
            for (int i = 0; i < number; i++)
                result[i] = func(i);
            return result;
        }
    }
}