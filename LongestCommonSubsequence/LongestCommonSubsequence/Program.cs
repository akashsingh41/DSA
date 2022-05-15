using System;

namespace LongestCommonSubsequence
{
    internal class Program
    {
        //recusrion approach - O(2^n) worst case when x & y mismatch
        static int lcs(char[] x, char[] y, int m, int n)
        {
            if(m==0 || n==0) return 0;
            if (x[m - 1] == y[n - 1])
                return 1 + lcs(x, y, m - 1, n - 1);
            else
                return Math.Max(lcs(x, y, m - 1, n), lcs(x, y, m, n - 1));
        }

        static int lcs2(char[] X, char[] Y, int m, int n)
        {
            int[,] L = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1] in bottom up fashion. Note that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] */
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else 
                        if (X[i - 1] == Y[j - 1])
                            L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }
            return L[m, n];
        }
        static void Main(string[] args)
        {
            String s1 = "AGGTAB";
            String s2 = "GXTXAYB";

            char[] X = s1.ToCharArray();
            char[] Y = s2.ToCharArray();
            int m = X.Length;
            int n = Y.Length;

            Console.Write("Length of LCS is "  + lcs2(X, Y, m, n));
        }
    }
}
