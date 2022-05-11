using System;
using System.Collections.Generic;

namespace TwoSumInArray
{
    class Program
    {
        static void printpairs(int[] arr,
                           int sum)
    {
        HashSet<int> s = new HashSet<int>();
        for (int i = 0; i < arr.Length; ++i)
        {
            int temp = sum - arr[i];
 
            // checking for condition
            if (s.Contains(temp)) {
                Console.Write("Pair with given sum is (" + arr[i] + ", " + temp + ")");
            }
            s.Add(arr[i]);
        }
    }
 
    // Driver Code
    static void Main()
    {
        int[] A = new int[] { 1, 4, 45, 6, 10, 8 };
        int n = 16;
        printpairs(A, n);
    }
    }
}
