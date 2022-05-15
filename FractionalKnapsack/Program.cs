using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FractionalKnapsack
{
    class item
    {
        public int value;
        public int weight;

        public item(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
        }
    }

    class ItemsCompare : IComparer<item>
    {
        public int Compare(item x, item y)
        {
            double ratio1 = x.value / x.weight;
            double ratio2 = y.value / y.weight;

            if (ratio1 < ratio2)
                return 1;
            else
                return ratio1 > ratio2 ? -1 : 0;
        }
    }
    class Program
    {

        static int fractionalKnapsack(item[] items, int limit)
        {
            ItemsCompare comparer = new ItemsCompare();
            Array.Sort(items, comparer);

            // Traverse items, if it can fit, take it all, else take fraction
            int current_weight = 0;
            double total_value = 0;
            foreach (item i in items)
            {
                int remaining = limit - current_weight;

                // If the whole item can be taken, take it
                if (i.weight <= remaining)
                {
                    total_value += i.value;
                    current_weight += i.weight;
                }
                else 
                {
                    if (remaining == 0)
                        break;

                    double fraction = remaining / (double)i.weight;
                    total_value += fraction * (double)i.value;
                    current_weight += (int)fraction * i.weight;
                }                
            }
            return (int)total_value;
        }

        static void Main(string[] args)
        {
            item[] array = {
                                    new item(60, 10),
                                    new item(100, 20),
                                    new item(120, 30) };

            Console.WriteLine("Maximum value we can obtain = " + fractionalKnapsack(array, 50));
        }
    }
 }

