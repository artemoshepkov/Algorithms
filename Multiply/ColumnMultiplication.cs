﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Multiply
{
    public class ColumnMultiplication
    {
        public static int Multiply(int a, int b)
        {
            var listResult = Svertka.CalculateCommon(SplitNumberToList(a), SplitNumberToList(b));

            for (int i = 0; i < listResult.Count; i++)
            {
                while (listResult[i] > 9)
                {
                    listResult[i] -= 10;

                    if (listResult.Count <= i + 1)
                        listResult.Add(0);

                    listResult[i + 1] += 1;
                }
            }

            listResult.Reverse();

            return FromListToNumber(listResult);
        }
        public static List<int> SplitNumberToList(int number)
        {
            var numberList = new List<int>();

            if (number == 0)
                numberList.Add(0);

            while (number > 0)
            {
                numberList.Add(number % 10);
                number /= 10;
            }

            return numberList;
        }
        public static int FromListToNumber(List<int> listNumber)
        {
            int number = listNumber.First();

            for (int i = 1; i < listNumber.Count; i++)
            {
                number *= 10;
                number += listNumber[i];
            }

            return number;
        }
    }
}