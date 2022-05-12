using System;
using System.Collections.Generic;

namespace MergeKSortedArrays
{
    internal class Program
    {
        static List<int> mergeKArrays(List<List<int>> a, int k)
        {
            List<int> result = new List<int>();

            // Create a min heap with k heap nodes. Every heap node has first element of an array
            List<Tuple<int, Tuple<int, int>>> pq = new List<Tuple<int, Tuple<int, int>>>();

            for (int i = 0; i < k; i++)
                pq.Add(new Tuple<int, Tuple<int, int>>(a[i][0], new Tuple<int, int>(i, 0)));

            pq.Sort();

            // Now one by one get the minimum element from min heap and replace it with next element of its array
            while (pq.Count > 0)
            {
                Tuple<int, Tuple<int, int>> current = pq[0];
                pq.RemoveAt(0);

                // i ==> Array Number
                // j ==> Index in the array number
                int i = current.Item2.Item1;
                int j = current.Item2.Item2;

                result.Add(current.Item1);

                // The next element belongs to same array as current.
                if (j + 1 < a[i].Count)
                {
                    pq.Add(new Tuple<int, Tuple<int, int>>(a[i][j + 1], new Tuple<int, int>(i, j + 1)));
                    pq.Sort();
                }
            }
            return result;
        }

        // Driver code
        static void Main()
        {            
            List<List<int>> array = new List<List<int>>();
            array.Add(new List<int>(new int[] { 2, 6, 12 }));
            array.Add(new List<int>(new int[] { 1, 9 }));
            array.Add(new List<int>(new int[] { 23, 34, 90, 2000 }));

            //array[1].AddRange(array[2]);
            //array[0].AddRange(array[1]);
            //array[0].Sort();
            //List<int> output = array[0];
            

           List<int> output = mergeKArrays(array, 3);

            Console.WriteLine("Merged Array is ");
            foreach (int x in output)
                Console.Write(x + " ");
        }
    }
}
