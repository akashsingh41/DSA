using System;

namespace MaxSumwithNoConsecutive
{
    class Program
    {
        static int maxSum(int[] arr)
        {
            int N = arr.Length;
            int[,] dp = new int[N, 2];

            if (N == 1) return arr[0];

            dp[0, 0] = 0;
            dp[0,1] = arr[0];

            for (int i = 1; i < N; i++)
            {
                dp[i, 1] = dp[i - 1, 0] + arr[i];
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            }

            return Math.Max(dp[N - 1, 1], dp[N - 1, 0]);
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 2, 5, 10, 7 };
            Console.WriteLine("maximum sum with no consecutive items picked:" +maxSum(array));
        }
    }
}
