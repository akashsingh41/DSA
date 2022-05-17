using System;

namespace _0_1KnapsackProblem
{
    class Program
    {
        static int knapsack(int max, int[] weights, int[] values, int n)
        {
            if (n == 0 || max == 0) return 0;
            if (weights[n - 1] > max)
                return knapsack(max, weights, values, n - 1);

            return Math.Max(values[n - 1] + knapsack(max - weights[n - 1], weights, values, n - 1), knapsack(max, weights, values, n - 1));
        }//recursive

        static int knapSack(int W, int[] wt, int[] val, int n) //DP - bottom up tabulation
        {            
            int[,] K = new int[n + 1, W + 1];

            for (int i = 0; i <= n; i++)
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else
                    {
                        if (wt[i - 1] <= w)
                            K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                        else
                            K[i, w] = K[i - 1, w];
                    }
                }
            return K[n, W];
            
        }
        static void Main(string[] args)
        {
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;

            Console.WriteLine(knapSack(W, wt, val, n));
        }
    }
}
