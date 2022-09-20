using System;
using System.Numerics;

namespace Algorithms.DFT
{
    public static class DiscreteFourierTransform
    {
        private static Complex _complexNumber = new Complex(0, 1);
        public static Complex[] DirectTransform(double [] array)
        {
            int numberOperations = 0;
            var DDFT = new Complex[array.Length];

            var N = array.Length;
            for (int k = 0; k < array.Length; k++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    DDFT[k] += GetComplexExpDegree(-2, k, j, N) * array[j];
                }
                DDFT[k] /= N;
            }

            return DDFT;
        }
        public static Complex[] ReverseTransform(Complex[] array)
        {
            int numberOperations = 0;

            var RDFT = new Complex[array.Length];

            var N = array.Length;
            for (int k = 0; k < array.Length; k++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    RDFT[k] += GetComplexExpDegree(2, k, j, N) * array[j];
                }
            }

            return RDFT;
        }

        private static Complex GetComplexExpDegree(int koef, int k, int j, int N)
        {
            var arg = koef * Math.PI * k * j / N;
            return new Complex(Math.Round(Math.Cos(arg)), Math.Round(Math.Sin(arg)));
        }
    }
}
