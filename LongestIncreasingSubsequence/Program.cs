using System;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static int lis(int[] arr, int n)
        {          
            int[] lis = new int[n];
            int i, j, max = 0;

            /* Initialize LIS values for all indexes */
            for (i = 0; i < n; i++)
                lis[i] = 1;

            /* Compute optimized LIS values in bottom up manner
             */
            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];

            return max;
        
    }
        static void Main(string[] args)
        {
            int[] arr = { 2, 10, 5, 1, 8, 6, 6, 6, 5 };
            int n = arr.Length;
            Console.Write("Length of longest increasing subsequence is " + lis(arr,n));
        }

        static int lisUsingLCS(int[] arr)
        {
            int[] unsorted = arr;
            Array.Sort(arr);

            return lcs(unsorted, arr,unsorted.Length,arr.Length);
        }

        static int lcs(int[] s1, int[] s2, int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            if (s1[m - 1] == s2[n - 1]) return lcs(s1, s2, m - 1, n - 1);
            return 1 + Math.Max(lcs(s1, s2, m - 1, n), lcs(s1, s2, m, n - 1));
        }
    }
}
