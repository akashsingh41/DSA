using System;

namespace LongestSubArrayWithSumDivisibleByK
{
    class Program
    {
        static int solution(int[] a, int k)
        {
            int length = a.Length;
            int window = length;
            while (window > 0)
            {
                int start = 0;
                int end=start+window-1;
                while(end<length){
                    int sum = 0;
                    for (int i = start; i <= end; i++)
                    {
                        sum += a[i];
                    }
                    if (sum % k == 0)
                        return window;
                    start++;
                    end++;
                }
                window--;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] A = { 1,2,-2,2,2 };
            int k = 2;
            Console.WriteLine(solution(A, k));
        }
    }
}
