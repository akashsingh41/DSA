using System;

namespace PalindromePartitioning
{
    class Program
    {
        #region using recursion
        static bool isPalindrome(string str, int i, int j) 
        {
            while (i < j)
            {
                if (str[i] != str[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }
        static int minPalindromePartition(string str, int i, int j)
        {            
            if (i >= j || isPalindrome(str, i, j))
                return 0;
            int answer = int.MaxValue, count=0;

            for (int k = i; k < j; k++)
            {
                count = minPalindromePartition(str, i, k) + minPalindromePartition(str, k + 1, j) + 1;
                answer = Math.Min(answer,count);
            }

            return answer;
        }
        #endregion

        static int minPalindromePartitionDP(string str)
        {
            // Get the length of the string
        int n = str.Length;

            /* Create two arrays to build the solution
            in bottom up manner
            C[i] = Minimum number of cuts needed for
            palindrome partitioning of substring
            str[0..i]
            P[i][j] = true if substring str[i..j] is
            palindrome, else false
            Note that C[i] is 0 if P[0][i] is true */
            int[] C = new int[n];
            bool[,] P = new bool[n, n];

            int i, j, L; // different looping variables

            // Every substring of length 1 is a palindrome
            for (i = 0; i < n; i++)
            {
                P[i, i] = true;
            }

            /* L is substring length. Build the solution
            in bottom up manner by considering all substrings
            of length starting from 2 to n. */
            for (L = 2; L <= n; L++)
            {
                // For substring of length L, set different
                // possible starting indexes
                for (i = 0; i < n - L + 1; i++)
                {
                    j = i + L - 1; // Set ending index

                    // If L is 2, then we just need to
                    // compare two characters. Else need to
                    // check two corner characters and value
                    // of P[i+1][j-1]
                    if (L == 2)
                        P[i, j] = (str[i] == str[j]);
                    else
                        P[i, j] = (str[i] == str[j]) && P[i + 1, j - 1];
                }
            }

            for (i = 0; i < n; i++)
            {
                if (P[0, i] == true)
                    C[i] = 0;
                else
                {
                    C[i] = int.MaxValue;
                    for (j = 0; j < i; j++)
                    {
                        if (P[j + 1, i] == true && 1 + C[j] < C[i])
                            C[i] = 1 + C[j];
                    }
                }
            }

            // Return the min cut value for complete
            // string. i.e., str[0..n-1]
            return C[n - 1];
        }
    
        static void Main(string[] args)
        {
            string str = "ababbbabbababa";
            Console.WriteLine("Min cuts needed for Palindrome Partitioning is " + minPalindromePartitionDP(str));
        }
    }
}
