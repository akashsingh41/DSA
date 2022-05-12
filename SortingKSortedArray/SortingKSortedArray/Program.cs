using System;
using System.Collections.Generic;

namespace SortingKSortedArray
{
    /*
     * We can sort such arrays more efficiently with the help of Heap data structure. Following is the detailed process that uses Heap. 
     * 1) Create a Min Heap of size k+1 with first k+1 elements. This will take O(k) time (See this GFact) 
     * 2) One by one remove min element from heap, put it in result array, and add a new element to heap from remaining elements.
     * Removing an element and adding a new element to min heap will take log k time. So overall complexity will be O(k) + O((n-k) * log(k)).
     */
    internal class Program
    {
        static void kSort(int[] arr, int n, int k)
        {
            // min heap - priority Queue            
            List<int> minHeap = new List<int>();

            // add first k + 1 items to the min heap
            for (int i = 0; i < k + 1; i++)
            {
                minHeap.Add(arr[i]);
            }

            minHeap.Sort();

            int index = 0;
            for (int i = k + 1; i < n; i++)
            {
                arr[index++] = minHeap[0];
                minHeap.RemoveAt(0);
                minHeap.Add(arr[i]);
                minHeap.Sort();
            }

            int heap_size = minHeap.Count;

            for (int i = 0; i < heap_size; i++)
            {
                arr[index++] = minHeap[0];
                minHeap.RemoveAt(0);
            }
        }
        static void Main(string[] args)
        {
            int k = 3;
            int[] array = { 2, 6, 3, 12, 56, 8 };
            int n = array.Length;
            kSort(array, n, k);
            Console.WriteLine("Following is sorted array");
            printArray(array, n);
        }
        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
