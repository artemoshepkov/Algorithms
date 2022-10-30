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
            var A = new int[,] { { 1,2,3,4, 5 },
                                    {1,2,3,4, 5 },
                                    {1,2,3,4, 5 },
                                    {1,2,3,4, 5 } };

            var B = new int[,] { { 1,2,3,4 },
                                    {1,2,3,4 },
                                    {1,2,3,4 },
                                    {1,2,3,4 },
                                    {1,2,3,4 } };

            var C = MatrixMultiplication.MultiplyMatrices(A, B);


            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                    Console.Write(C[i, j] + " ");
                Console.WriteLine();
            }
        }

        private static void TestMultiplyNumbers()
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