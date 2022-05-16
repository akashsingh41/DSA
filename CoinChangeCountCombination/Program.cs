﻿using System;

namespace CoinChangeCountCombination
{
    class Program
    {
        //recursion
        static int count1(int[] array, int m, int n)
        {
            if (n == 0) return 1;
            if (n < 0) return 0;
            if (m <= 0 && n >= 1) return 0;
            return (count1(array, m - 1, n) + count1(array, m, n - array[m-1]));
        }

        static int count2(int[] array, int m, int n)
        {
            // table[i] will be storing the number of solutions for value i.
            // We need n+1 rows as the table is constructed in bottom up manner using the base case (n = 0)
            int[] table = new int[n + 1];

            //// Initialize all table values as 0
            //for (int i = 0; i < table.Length; i++)
            //{
            //    table[i] = 0;
            //}

            //base case: n=0;
            table[0] = 1;

            // Pick all coins one by one and update the table[] values after the index greater than or equal to the value of the picked coin
            for (int i = 0; i < m; i++)
                for (int j = array[i]; j <= n; j++)
                    table[j] += table[j - array[i]];

            return table[n];
        }

        static void Main(string[] args)
        {
            int[] array = {  2, 3 ,5,6};
            int N = 10;
            Console.WriteLine(count2(array, array.Length, N));
        }
    }
}
