using System;

namespace EditDistance
{
    class Program
    {
        static int min(int a, int b, int c)
        {
            if ((a < b) && (a < c)) return a;
            if ((b < a) && (b < c)) return b;
            return c;
        }
        //naive
        static int editDistance(string S1, string S2, int m, int n)
        {
            if (m == 0) return n;
            if (n == 0) return m;
            if (S1[m - 1] == S2[n - 1])
                return editDistance(S1, S2, m - 1, n - 1);

            return 1 + min(editDistance(S1, S2, m, n - 1),//insert
                                       editDistance(S1, S2, m - 1, n),//remove
                                       editDistance(S1, S2, m - 1, n - 1));//replace
                
        }

        static int editDistanceDP(string str1, string str2)
        {
          
                int len1 = str1.Length;
                int len2 = str2.Length;

                // Create a DP array to memoize result of previous computations
                int[,] DP = new int[2, len1 + 1];

                // Base condition when second String is empty then we remove all characters
                for (int i = 0; i <= len1; i++)
                    DP[0, i] = i;

                // Start filling the DP
                // This loop run for every character in second String
                for (int i = 1; i <= len2; i++)
                {
                    // This loop compares the char from second String with first String characters
                    for (int j = 0; j <= len1; j++)
                    {
                        // if first String is empty then we have to perform add character operation to get second String
                        if (j == 0)
                            DP[i % 2, j] = i;

                        // if character from both String is same then we do not perform any operation . here i % 2 is for bound the row number.
                        else if (str1[j - 1] == str2[i - 1])
                        {
                            DP[i % 2, j] = DP[(i - 1) % 2, j - 1];
                        }

                        // if character from both String is not same then we take the minimum from three specified operation
                        else
                        {
                            DP[i % 2, j] = 1 + Math.Min(DP[(i - 1) % 2, j],  Math.Min(DP[i % 2, j - 1],  DP[(i - 1) % 2, j - 1]));
                        }
                    }
                }

                // after complete fill the DP array if the len2 is even then we end up in the 0th row else we end up in the 1th row so we take len2 % 2 to get row
                return DP[len2 % 2, len1];
            
        }

        static void Main(string[] args)
        {
            string s1 = "sunday";
            string s2 = "saturday";

            //Console.WriteLine("edit distance: "+editDistance(s1,s2,s1.Length,s2.Length));
            Console.WriteLine(  editDistanceDP(s1, s2));

        }
    }
}
