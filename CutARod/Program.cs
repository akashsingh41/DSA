#region unbounded knapsack approach
//using System;
//public class GFG
//{

//	// Global Array for
//	// the purpose of memoization.
//	static int[,] t = new int[9, 9];

//	// A recursive program, using ,
//	// memoization, to implement the
//	// rod cutting problem(Top-Down).
//	public static int un_kp(int[] price, int[] length, int Max_len, int n)
//	{

//		// The maximum price will be zero,
//		// when either the length of the rod
//		// is zero or price is zero.
//		if (n == 0 || Max_len == 0)
//		{
//			return 0;
//		}

//		// If the length of the rod is less
//		// than the maximum length, Max_lene will
//		// consider it.Now depending
//		// upon the profit,
//		// either Max_lene we will take
//		// it or discard it.
//		if (length[n - 1] <= Max_len)
//		{
//			t[n, Max_len] = Math.Max(price[n - 1] + un_kp(price, length, Max_len - length[n - 1], n),
//									un_kp(price, length, Max_len, n - 1));
//		}

//		// If the length of the rod is
//		// greater than the permitted size,
//		// Max_len we will not consider it.
//		else
//		{
//			t[n, Max_len] = un_kp(price, length, Max_len, n - 1);
//		}

//		// Max_lene Max_lenill return the maximum
//		// value obtained, Max_lenhich is present
//		// at the nth roMax_len and Max_length column.
//		return t[n, Max_len];
//	}

//	// Driver code
//	public static void Main(String[] args)
//	{
//		int[] price = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
//		int n = price.Length;
//		int[] length = new int[n];
//		for (int i = 0; i < n; i++)
//		{
//			length[i] = i + 1;
//		}
//		int Max_len = n;
//		Console.WriteLine("Maximum obtained value is " + un_kp(price, length, n, Max_len));
//	}
//}

#endregion


using System;

namespace CutARod
{
    class Program
    {
        static int cutRod(int[] array, int n)
        {
            int[] val = new int[n + 1];
            val[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                int max_val = int.MinValue;
                for (int j = 0; j < i; j++)
                {
                    max_val = Math.Max(max_val, array[j] + val[i - j - 1]);
                }
                val[i] = max_val;
            }
            return val[n];
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
            int n = array.Length;
            Console.WriteLine(cutRod(array, n));
        }
    }
}


