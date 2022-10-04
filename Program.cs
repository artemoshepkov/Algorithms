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
            var array1 = new double[] { 1,2,3,4,};
            var array2 = new double[] { 5,6};

            var res = Svertka.Run(array1, array2);

            res.ToList().ForEach(x => Console.WriteLine(x));






            //var complexArray = new Complex[] { new Complex(1, 0), new Complex(2, 0), new Complex(3, 0), new Complex(4, 0), new Complex(5, 0), new Complex(6, 0) };
            //complexArray.Print();

            //int numberOperations;

            //string numbetMask = "0.00000";

            //var directTransformedArray = DiscreteFourierTransform.DirectTransform(complexArray, out numberOperations);
            //Console.Write(numberOperations + " :\n");
            //foreach (var item in directTransformedArray)
            //{
            //    Console.WriteLine("("+ item.Real.ToString(numbetMask) + ", " + item.Imaginary.ToString(numbetMask) + ")");
            //}

            //var reverseTransformedArray = DiscreteFourierTransform.ReverseTransform(directTransformedArray, out numberOperations);
            //Console.Write(numberOperations + " :\n");
            //foreach (var item in reverseTransformedArray)
            //{
            //    Console.WriteLine("(" + item.Real.ToString(numbetMask) + ", " + item.Imaginary.ToString(numbetMask) + ")");
            //}

            //Console.WriteLine("----------------------------------");

            //var directTransformedArray1 = SemiFastDFT.DirectTransform(complexArray, out numberOperations);
            //Console.Write(numberOperations + " :\n");
            //foreach (var item in directTransformedArray)
            //{
            //    Console.WriteLine("(" + item.Real.ToString(numbetMask) + ", " + item.Imaginary.ToString(numbetMask) + ")");
            //}

            //var reverseTransformedArray1 = SemiFastDFT.ReverseTransform(directTransformedArray, out numberOperations);
            //Console.Write(numberOperations + " :\n");
            //foreach (var item in reverseTransformedArray)
            //{
            //    Console.WriteLine("(" + item.Real.ToString(numbetMask) + ", " + item.Imaginary.ToString(numbetMask) + ")");
            //}

            // WriteDFT(DiscreteFourierTransform.DirectTransform, complexArray);
        }
        private static void WriteDFT(Func<Complex[], int, Complex[]> func, Complex[] array, string numberMask = "0.00000")
        {
            int numberOperations = 0;
            var dft = func(array, numberOperations);
            Console.Write(numberOperations + " :\n");
            foreach (var item in dft)
            {
                Console.WriteLine("(" + item.Real.ToString(numberMask) + ", " + item.Imaginary.ToString(numberMask) + ")");
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