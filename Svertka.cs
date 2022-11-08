using Algorithms.DFT;
using System.Numerics;

namespace Algorithms
{
    public class Svertka
    {
        public static int[] CalculateCommon(int[] array1, int[] array2, ref int count)
        {
            var result = new int[array1.Length + array2.Length - 1];

            for (int k = 0; k < array1.Length; k++)
                for (int l = 0; l < array2.Length; l++)
                {
                    result[k + l] += array1[k] * array2[l];
                    count += 2;
                }

            return result;
        }
        public static List<int> CalculateCommon(List<int> array1, List<int> array2, ref int count)
        {
            var result = new List<int>(array1.Count + array2.Count - 1);

            for (int i = 0; i < array1.Count + array2.Count - 1; i++)
                result.Add(0);

            for (int k = 0; k < array1.Count; k++)
                for (int l = 0; l < array2.Count; l++)
                {
                    result[k + l] += array1[k] * array2[l];
                    count += 2;
                }

            return result;
        }
    }
}
