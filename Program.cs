using Algorithms.ConsoleOutput;
using Algorithms.DFT;
using Algorithms.Sorts;
using System.Numerics;

namespace Algorithms
{
    public class Program
    {
        private static void Main()
        {
            var complexArray = new Complex[] { new Complex(2, 0), new Complex(1, 0), new Complex(0, 0) };
            complexArray.Print();

            int numberOperations;

            var directTransformedArray = DiscreteFourierTransform.DirectTransform(complexArray, out numberOperations);
            Console.Write(numberOperations + " :\n");
            foreach (var item in directTransformedArray)
            {
                Console.WriteLine(item);
            }

            var reverseTransformedArray = DiscreteFourierTransform.ReverseTransform(directTransformedArray, out numberOperations);
            Console.Write(numberOperations + " :\n");
            foreach (var item in reverseTransformedArray)
            {
                Console.WriteLine("(" + Math.Round(item.Real) + ", " + Math.Round(item.Imaginary) + ")");
            }

            Console.WriteLine("----------------------------------");

            var directTransformedArray1 = SemiFastDFT.DirectTransform(complexArray, out numberOperations);
            Console.Write(numberOperations + " :\n");
            foreach (var item in directTransformedArray)
            {
                Console.WriteLine(item);
            }

            var reverseTransformedArray1 = SemiFastDFT.ReverseTransform(directTransformedArray, out numberOperations);
            Console.Write(numberOperations + " :\n");
            foreach (var item in reverseTransformedArray)
            {
                Console.WriteLine("(" + Math.Round(item.Real) + ", " + Math.Round(item.Imaginary) + ")");
            }
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