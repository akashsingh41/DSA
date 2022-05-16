using System;

namespace MinimumCoinsToMakeAValue
{
    class Program
    {
        static int minNoOfCoins(int[] coins, int n, int V)
        {
            if (V == 0) return 0;

            int result = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (coins[i] <= V)
                {
                    int sub_result = minNoOfCoins(coins, n, V - coins[i]);

                    if (sub_result != int.MaxValue && sub_result + 1 < result)
                        result = sub_result + 1;
                }
            }
            return result;

        }

        static int minCoinsDP(int[] coins, int n, int V)
        {
            int[] table = new int[V + 1];
            table[0] = 0;

            for (int i = 1; i <= V; i++)
            {
                table[i] = int.MaxValue;
            }
            // Compute minimum coins required for all values from 1 to V
            for (int i = 1; i <= V; i++)
            {
                // Go through all coins smaller than i
                for (int j = 0; j < n; j++)
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue && sub_res + 1 < table[i])
                            table[i] = sub_res + 1;
                    }
            }

            return table[V]==int.MaxValue?-1:table[V];
        }
        static void Main(string[] args)
        {
            int[] coin_types = { 15, 11 };
            int n = coin_types.Length;

            int limit = 4;

            Console.WriteLine(minCoinsDP(coin_types,n,limit));
        }
    }
}
