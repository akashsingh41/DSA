using System;

namespace MinimumNoOfJumpsToReach
{
    class Program
    {
        static int minJumps(int[] array, int n)
        {
            int[] jumps = new int[n];

            // if first element is 0,
            if (n == 0 || array[0] == 0)

                // end cannot be reached
                return int.MaxValue;

            jumps[0] = 0;

            // Find the minimum number of jumps to reach arr[i] from arr[0], and assign this value to jumps[i]
            for (int i = 1; i < n; i++)
            {
                jumps[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i <= j + array[j] && jumps[j] != int.MaxValue)
                    {
                        jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                        break;
                    }
                }
            }
            return jumps[n - 1];
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {2,0,0,1,0,0 };
            int size = arr.Length;
            Console.WriteLine("Minimum number of jumps to reach end is " + minJumps(arr, size));
        }
    }
}
