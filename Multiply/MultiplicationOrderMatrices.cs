using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Multiply
{
    public struct Matrix
    {
        public string Order = "";
        public int Cost = 0;

        public Matrix(string order)
        {
            Order = order;
        }
    }

    public class MultiplicationOrderMatrices
    {
        public static Tuple<int, string> GetOrder(int[] sizes)
        {
            var n = sizes.Length - 1;
            var f = new Matrix[n, n];

            for (int i = 0; i < n; i++)
                f[i, i] = new Matrix("M" + i);

            for (int l = 1; l < n; ++l)
            {
                for (int i = 0; i < n - l; ++i)
                {
                    var j = i + l;
                    f[i, j].Cost = int.MaxValue;
                    for (int k = i; k < j; ++k)
                    {
                        var temp = f[i, k].Cost + f[k + 1, j].Cost + sizes[i] * sizes[k + 1] * sizes[j + 1];
                        if (temp < f[i, j].Cost)
                        {
                            f[i, j].Cost = temp;
                            f[i, j].Order = "(" + f[i, k].Order + " * " + f[k + 1, j].Order + ")";
                        }
                    }
                }
            }

            return Tuple.Create(f[0, f.GetLength(0) - 1].Cost, f[0, f.GetLength(0) - 1].Order);
        }
    }
}
