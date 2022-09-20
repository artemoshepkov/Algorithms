using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class MyExtensions
    {
        public static void Print<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
