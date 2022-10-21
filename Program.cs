using Algorithms.ConsoleOutput;
using Algorithms.DFT;
using Algorithms.Multiply;
using Algorithms.Sorts;
using System.Numerics;

namespace Algorithms
{
    // 10:20 a.m.
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine(ColumnMultiplication.Multiply(123, 123));
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