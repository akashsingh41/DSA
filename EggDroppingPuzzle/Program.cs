using System;

namespace EggDroppingPuzzle
{
    class Program
    {
        static int eggDrop(int n, int k)
        {
            // If there are no floors, then no trials needed. OR if there is one floor, one trial needed.
            if (k == 1 || k == 0)
                return k;

            // We need k trials for one egg and k floors
            if (n == 1)
                return k;

            int min = int.MaxValue;
            int x, result ;

            // Consider all droppings from 1st floor to kth floor and return the minimum of these values plus 1.
            for (x = 1; x <= k; x++)
            {
                result = Math.Max(eggDrop(n - 1, x - 1), eggDrop(n, k - x));
                if (result < min)
                    min = result;
            }

            return min + 1;
        }
        static void Main(string[] args)
        {
            int n = 2, k = 10;
            Console.Write($"Minimum number of trials in worst case with {n} eggs and {k} floors is {eggDrop(n, k)}");
        }
    }
}
