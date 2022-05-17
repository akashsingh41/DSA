using System;

namespace OPtimalStrategyForAGame
{
    class Program
    {

        /*
         * F(i, j) represents the maximum value the user can collect from i'th coin to j'th coin.
         * 
         * F(i, j) = Max(Vi + min(F(i+2, j), F(i+1, j-1) ), Vj + min(F(i+1, j-1), F(i, j-2) ))
         * 
         * As user wants to maximise the number of coins. 
         * Base Cases
         * F(i, j) = Vi                  If j == i
         * F(i, j) = max(Vi, Vj)  If j == i + 1
         * 
         */
        static int optimalStrategyOfGame(int[] array, int n)
        {
            int[,] F = new int[n, n];
            int x, y, z, itr, i, j;
            for (itr = 0; itr < n; itr++)
            {
                for (i = 0, j = itr; j < n; j++, i++)
                {
                    x = (i + 2) <= j ? F[i + 2, j] : 0; //F(i+2,j)
                    y = i + 1 <= j - 1 ? F[i + 1, j - 1] : 0;
                    z = i <= j - 2 ? F[i, j - 2] : 0;

                    F[i, j] = Math.Max(array[i] + Math.Min(x, y),  array[j] + Math.Min(y, z));
                }
            }
            return F[0, n - 1];
        }

        static void Main(string[] args)
        {
            int[] arr1 = { 8, 15, 3, 7 };
            int n = arr1.Length;
            Console.WriteLine("" + optimalStrategyOfGame(arr1, n));

            int[] arr2 = { 2, 2, 2, 2 };
            n = arr2.Length;
            Console.WriteLine("" + optimalStrategyOfGame(arr2, n));

            int[] arr3 = { 20, 30, 2, 2, 2, 10 };
            n = arr3.Length;
            Console.WriteLine("" + optimalStrategyOfGame(arr3, n));
        }
    }
}
