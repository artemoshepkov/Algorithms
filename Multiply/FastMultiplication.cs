using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Multiply
{
    public class FastMultiplication
    {
        public static int Multiply(int num1, int num2)
        {
            return FromListToNumber(Multiply(SplitNumberToList(num1), SplitNumberToList(num2)));
        }

        public static List<int> Multiply(List<int> x, List<int> y)
        {
            var numX = DeleteExtraZeros(x);
            var numY = DeleteExtraZeros(y);
            if (FromListToNumber(numX) < 10 && FromListToNumber(numY) < 10)
                return ColumnMultiplication.Multiply(numX, numY);

            var length = Math.Max(x.Count, y.Count);
            length += length % 2 == 0 ? 0 : 1;

            NumberListExtend(x, length);
            NumberListExtend(y, length);

            var xl = new List<int>(x.GetRange(length / 2, length / 2));
            var xr = new List<int>(x.GetRange(0, length / 2));
            var yl = new List<int>(y.GetRange(length / 2, length / 2));
            var yr = new List<int>(y.GetRange(0, length / 2));

            var u = Multiply(SumBinNumberLists(xl, xr), SumBinNumberLists(yl, yr));
            var v = Multiply(xl, yl);
            var w = Multiply(xr, yr);

            var firstPart = MultiplyBinNumberLists(v, SplitNumberToList((int)Math.Pow(2, length))); // v * 2^2k
            var secondPart = MultiplyBinNumberLists(
                    DifferenceBinNumberLists(DifferenceBinNumberLists(u, v), w), // (u - v - w) 
                    SplitNumberToList((int)Math.Pow(2, length / 2)) // 2^k
                ); // (u - v - w) * 2^k
            var sumFirst_SecondParts = SumBinNumberLists(firstPart, secondPart); // v * 2^2k + (u - v - w) * 2^k

            return SumBinNumberLists(sumFirst_SecondParts, w); // v * 2^2k + (u - v - w) * 2^k  + w
        }

        public static void NumberListExtend(List<int> number, int n)
        {
            var countNewElements = n - number.Count;

            for (int i = 0; i < countNewElements; i++)
                number.Add(0);
        }

        public static List<int> SumBinNumberLists(List<int> x, List<int> y)
        {
            return SplitNumberToList(FromListToNumber(x) + FromListToNumber(y));
        }

        public static List<int> MultiplyBinNumberLists(List<int> x, List<int> y)
        {
            return SplitNumberToList(FromListToNumber(x) * FromListToNumber(y));
        }

        public static List<int> DifferenceBinNumberLists(List<int> x, List<int> y)
        {
            return SplitNumberToList(FromListToNumber(x) - FromListToNumber(y));
        }

        public static List<int> SplitNumberToList(int number)
        {
            var numberList = new List<int>();

            if (number == 0)
                numberList.Add(0);

            while (number > 0)
            {
                numberList.Add(number % 2);
                number /= 2;
            }

            return numberList;
        }

        public static List<int> DeleteExtraZeros(List<int> number)
        {
            int beginNumber = number.Count - 1;

            while (beginNumber > 0 && number[beginNumber] == 0)
                beginNumber--;

            return new List<int>(number.GetRange(0, beginNumber + 1));
        }

        private static int FromListToNumber(List<int> listNumber)
        {
            int number = 0;

            for (int i = 0; i < listNumber.Count; i++)
            {
                number += (int)Math.Pow(2, i) * listNumber[i];
            }

            return number;
        }
    }
}
