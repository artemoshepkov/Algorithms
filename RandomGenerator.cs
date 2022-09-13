using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class RandomGenerator
    {
        public static int[] GenerateArray(int size, int minValue, int maxValue)
        {
            var random = new Random();
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(minValue, maxValue);

            return array;
        }
    }
}
