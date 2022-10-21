using System;
using System.Numerics;

namespace Algorithms.DFT
{
    public static class DiscreteFourierTransform
    {
        public static Complex[] DirectTransform(double[] array)
        {
            return DirectTransform(array.Select(x => new Complex(x, 0)).ToArray());
        }
        public static Complex[] DirectTransform(Complex[] array)
        {
            //numberOperations = 0;

            var DDFT = new Complex[array.Length];

            var N = array.Length;
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    var arg = 2 * Math.PI * k * j / N;
                    DDFT[k] += GetComplexExpDegree(arg, -1) * array[j];
                    //numberOperations += 5;
                }
                DDFT[k] /= N;
            }

            return DDFT;
        }
        public static Complex[] ReverseTransform(Complex[] array)
        {
            //numberOperations = 0;

            var RDFT = new Complex[array.Length];

            var N = array.Length;
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    var arg = 2 * Math.PI * k * j / N;
                    RDFT[k] += GetComplexExpDegree(arg, 1) * array[j];
                    //numberOperations += 5;
                }
            }

            return RDFT;
        }

        private static Complex GetComplexExpDegree(double arg, int sign)
        {
            return new Complex(Math.Cos(arg), (sign * Math.Sin(arg)));
        }
    }
}
