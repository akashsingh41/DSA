using System;
using System.Collections.Generic;

namespace ActivitySelectionProblem
{
    class Program
    {
        // Prints a maximum set of activities that can be done by a single person, one at a time.
        // n --> Total number of activities
        // s[] --> An array that contains start time of all activities
        // f[] --> An array that contains finish time of all activities
        public static void printMaxActivities(int[] s, int[] f, int n)
        {
            int i=0, j;
            Console.WriteLine("Following activities are selected : ");
            Console.Write(i+" ");            
            

            for (j = 1; j < n; j++)
            {
                if (s[j] >= f[i])
                {
                    Console.Write(j + " ");
                    i = j;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] s = { 1, 3, 0, 5, 8, 5 };
            int[] f = { 2, 4, 6, 7, 9, 9 };
            int n = s.Length;

            printMaxActivities(s, f, n);
            }
    }
}
