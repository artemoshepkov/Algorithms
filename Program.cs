using Algorithms.ConsoleOutput;
using Algorithms.DFT;
using Algorithms.Sorts;

namespace Algorithms
{
    public class Program
    {
        private static void Main()
        {
            var array = GetArrayFunc(x => x / 2, 10);
            array.Print();
            var directTransformedArray = DiscreteFourierTransform.DirectTransform(array);
            directTransformedArray.Print();
            DiscreteFourierTransform.ReverseTransform(directTransformedArray).Print();
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