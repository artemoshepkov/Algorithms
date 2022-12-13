using Algorithms.Multiply;

namespace Algorithms
{
    public class Program
    {
        private static void Main()
        {
            var A = new int[,] { 
                { 1, 2, 3, 4}, 
                { 1, 2, 3, 4 }, 
                { 1, 2, 3, 4 }, 
                { 1, 2, 3, 4 }, };
            var B = new int[,] { 
                { 1, 2, 3, 4 }, 
                { 1, 2, 3, 4 }, 
                { 1, 2, 3, 4 }, 
                { 1, 2, 3, 4 },};

            TestMatricesMultiply(A, B, true);

            Console.WriteLine("---------------------------");

            TestMatricesMultiply(100, false);
        }

        private static void TestMatricesMultiply(int size, bool isOut)
        {
            var A = new int[size, size];
            var B = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    B[i, j] = j;
                    A[i, j] = j;
                }
            }

            TestMatricesMultiply(A, B, false);
        }

        private static void TestMatricesMultiply(int[,] A, int[,] B, bool isOut)
        {
            var C = MatrixMultiplication.MultiplyMatrices(A, B);


            if (isOut)
            {
                for (int i = 0; i < C.GetLength(0); i++)
                {
                    for (int j = 0; j < C.GetLength(1); j++)
                        Console.Write(C[i, j] + " ");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Operation count fast multiplication- {0}", MatrixMultiplication.OperationCount);

            int operationNumber = 0;
            C = MatrixMultiply(A, B, ref operationNumber);


            if (isOut)
            {
                for (int i = 0; i < C.GetLength(0); i++)
                {
                    for (int j = 0; j < C.GetLength(1); j++)
                        Console.Write(C[i, j] + " ");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Operation count common multiplication - {0}", operationNumber);
        }

        private static int[,] MatrixMultiply(int[,] A, int[,] B, ref int operationNumber)
        {
            var result = new int[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                        operationNumber += 1;
                    }
                }
            }

            return result;
        }
    }
}