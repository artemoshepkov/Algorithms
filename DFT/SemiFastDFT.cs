using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DFT
{
    public static class SemiFastDFT
    {
        public static Complex[] DirectTransform(Complex[] array, out int numberOperations)
        {
            numberOperations = 0;

            var DDFT = new Complex[array.Length];

            var N = array.Length;

            int p1 = 0;
            int p2 = 0;
            for (int i = 2; i <= N; i++)
            {
                if (N % i == 0)
                {
                    p1 = i;
                    p2 = N / i;
                    break;
                }
            }

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j / p2 < p1; j++)
                {
                    var j1 = j / p2;
                    var j2 = j % p2;
                    var k1 = k / p1;
                    var arg = 2 * Math.PI * j1 * k1 / p1;
                    DDFT[k] += array[j2 + p2 * j1] * GetComplexExpDegree(arg, -1);
                }
                DDFT[k] /= p1;

                for (int j = 0; j % p2 < p2; j++)
                {
                    var j1 = j / p2;
                    var j2 = j % p2;
                    var k1 = k / p1;
                    var k2 = k % p1;
                    var arg = 2 * Math.PI * (j2 / (p1 * p2) * (k1 + p1 * k2));
                    DDFT[k] += DDFT[k] * GetComplexExpDegree(arg, -1);
                }
                DDFT[k] /= p2;
            }

            return DDFT;
        }
        public static Complex[] ReverseTransform(Complex[] array, out int numberOperations)
        {
            numberOperations = 0;

            var RDFT = new Complex[array.Length];

            //var N = array.Length;
            //for (int k = 0; k < N; k++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        var arg = CalculateArg(k, j, N);
            //        RDFT[k] += GetComplexExpDegree(arg, 1) * array[j];
            //        numberOperations++;
            //    }
            //}

            return RDFT;
        }
        private static double CalculateArg(int k1, int k2, int p1, int p2, int j1, int j2) => 2 * Math.PI * ((k1 + p1 * k2) * (j2 + p2 * j1)) / (p1 * p2);
        private static Complex GetComplexExpDegree(double arg, int sign)
        {
            return new Complex(Math.Cos(arg), (sign * Math.Sin(arg)));
        }
    }
}
