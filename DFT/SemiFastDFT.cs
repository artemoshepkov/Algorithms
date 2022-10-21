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

            var p = CalculateTwoMultiplier(N);

            var p1 = p.Item1;
            var p2 = p.Item2;

            Console.WriteLine("p1 = {0}, p2 = {1}", p1, p2);

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < p1; j++)
                {
                    var j1 = j / p2;
                    var j2 = j % p2;
                    var k1 = k / p1;
                    var arg = 2 * Math.PI * j1 * k1 / p1;
                    DDFT[k] += array[j] * GetComplexExpDegree(arg, -1);
                    numberOperations += 5;
                }
                DDFT[k] /= p1;

                for (int j = 0; j < p2; j++)
                {
                    var j2 = j % p2;
                    var k1 = k / p1;
                    var k2 = k % p1;
                    var arg = 2 * Math.PI * j2 * k / N;
                    DDFT[k] += DDFT[k] * GetComplexExpDegree(arg, -1);
                    numberOperations += 5;
                }
                DDFT[k] /= p2;
            }

            return DDFT;
        }
        public static Complex[] ReverseTransform(Complex[] array, out int numberOperations)
        {
            numberOperations = 0;

            var DDFT = new Complex[array.Length];

            var N = array.Length;

            var p = CalculateTwoMultiplier(N);

            var p1 = p.Item1;
            var p2 = p.Item2;

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < p1; j++)
                {
                    var j1 = j / p1;
                    var j2 = j % p2;
                    var k1 = k / p1;
                    double arg = 2 * Math.PI * (double)(j1 * k1 / p1);
                    DDFT[k] += array[j2 + p2 * j1] * GetComplexExpDegree(arg, 1);
                    numberOperations += 5;
                }

                for (int j = 0; j < p2; j++)
                {
                    var j2 = j % p2;
                    var k1 = k / p1;
                    var k2 = k % p1;
                    double arg = 2 * Math.PI * (double)(j2 / (p1 * p2) * (k1 + p1 * k2));
                    DDFT[k] += DDFT[k] * GetComplexExpDegree(arg, 1);
                    numberOperations += 5;
                }
            }

            return DDFT;
        }
        
        private static Tuple<int, int> CalculateTwoMultiplier(int N)
        {
            for (int i = 2; i <= N; i++)
                if (N % i == 0)
                    return Tuple.Create(i, N / i);
            return Tuple.Create(1, N);
        }
        private static Complex GetComplexExpDegree(double arg, int sign)
        {
            return new Complex(Math.Cos(arg), (sign * Math.Sin(arg)));
        }
    }
}
