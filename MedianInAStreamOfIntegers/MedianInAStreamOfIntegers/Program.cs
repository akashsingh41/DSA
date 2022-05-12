using System;
using System.Collections.Generic;

namespace MedianInAStreamOfIntegers
{
    internal class Program
    {
        static void printMedian(int[] array)
        {
            int n = array.Length;
            MinHeap mh = new MinHeap();
            mh.heapSort(array);

            int size = array.Length;
            int median = 0;
            if (size % 2 == 0)
                median = (array[size / 2] + array[(size / 2) - 1]) / 2;
            else
                median = array[(size / 2)];

            Console.WriteLine(median);           
        }

        static void Main(string[] args)
        {
            int[] A = { 5, 15, 1, 3, 2, 8, 7, 9, 10, 6, 11, 4 };
            printMedian(A);
            Console.ReadKey();
        }
    }
}
