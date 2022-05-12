using System;

namespace HeapSort
{
    internal class Program
    {
        static void printArray(int[] a) 
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(a[i] + " ");            
        }
        static void heapSort(int[] a) 
        {           
            // Build heap (rearrange array)
            for (int i = a.Length / 2 - 1; i >= 0; i--)
                heapify(a, a.Length, i);

            // One by one extract an element from heap
            for (int i = a.Length - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = a[0];
                a[0] = a[i];
                a[i] = temp;

                // call max heapify on the reduced heap
                heapify(a, i, 0);
            }
        }

        // To heapify a subtree rooted with node i which is an index in a[]. n is size of heap
        static void heapify(int[] a, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // If left child is larger than root
            if (l < n && a[l] > a[largest])
                largest = l;

            // If right child is larger than largest so far
            if (r < n && a[r] > a[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                int temp = a[i];
                a[i] = a[largest];
                a[largest] = temp;

                // Recursively heapify the affected sub-tree
                heapify(a, n, largest);
            }
        }

        public static void Main()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            int n = arr.Length;
            Console.WriteLine("Input array is:");
            printArray(arr);

            heapSort(arr);

            Console.WriteLine("\nSorted array is:");
            printArray(arr);
        }
    }
}
