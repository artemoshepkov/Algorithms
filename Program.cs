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
            var complexArray = new Complex[] { new Complex(2, 1), new Complex(2, 2), new Complex(2, 3), new Complex(2, 2), new Complex(2, 1) };
            complexArray.Print();

            int numberOperations;

            var directTransformedArray = DiscreteFourierTransform.DirectTransform(complexArray, out numberOperations);
            Console.Write(numberOperations + " : ");
            directTransformedArray.Print();

            var reverseTransformedArray = DiscreteFourierTransform.ReverseTransform(directTransformedArray, out numberOperations);
            Console.Write(numberOperations + " : ");
            reverseTransformedArray.Print();
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