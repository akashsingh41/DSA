using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianInAStreamOfIntegers
{
    public class MinHeap
    {
        public void heapSort(int[] a)
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
    }
}
