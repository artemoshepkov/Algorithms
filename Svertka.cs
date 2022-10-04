using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Svertka
    {
        public static double[] Run(double[] array1, double[] array2)
        {
            var numberOperation = 0;

            var result = new double[array1.Length + array2.Length - 1];

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; i - j >= 0;  j++)
                {
                    if(j < array1.Length && i - j < array2.Length)
                    {
                        result[i] += array1[j] * array2[i - j];
                        numberOperation += 2;
                    }
                }
            }

            Console.WriteLine("number of operations - " + numberOperation);

            return result;

        }
    }
}
