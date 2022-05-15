using System;
using System.Collections.Generic;

#region Simple Greedy Approach
class JobComparison : IComparer<Job>
{
    public int Compare(Job x, Job y)
    {
        if (x.profit == 0 || y.profit == 0)
        {
            return 0;
        }

        // CompareTo() method
        return (y.profit).CompareTo(x.profit);
    }
}
public class Job
{
    // Each job has a unique-id, profit and deadline
    char id;
    public int deadline, profit;

    // Constructors
    public Job() { }

    public Job(char id, int deadline, int profit)
    {
        this.id = id;
        this.deadline = deadline;
        this.profit = profit;
    }

    // Function to schedule the jobs take 2 arguments arraylist and no of jobs to schedule
    public void printJobScheduling(List<Job> jobs, int t)
    {
        // Length of array
        int n = jobs.Count;

        JobComparison jobComparison = new JobComparison();
        // Sort all jobs according to decreasing order of profit
        jobs.Sort(jobComparison);

        // To keep track of free time slots
        bool[] result = new bool[t];

        // To store result (Sequence of jobs)
        char[] job = new char[t];

        // Iterate through all given jobs
        for (int i = 0; i < n; i++)
        {
            // Find a free slot for this job
            // (Note that we start from the last possible slot)
            for (int j = Math.Min(t - 1, jobs[i].deadline - 1); j >= 0; j--)
            {
                // Free slot found
                if (result[j] == false)
                {
                    result[j] = true;
                    job[j] = jobs[i].id;
                    break;
                }
            }
        }

        // Print the sequence
        foreach (char jb in job)
        {
            Console.Write(jb + " ");
        }
        Console.WriteLine();
    }
}
#endregion
public class Program
{
    static public void Main()
    {

        List<Job> arr = new List<Job>();

        arr.Add(new Job('a', 2, 100));
        arr.Add(new Job('b', 1, 19));
        arr.Add(new Job('c', 2, 27));
        arr.Add(new Job('d', 1, 25));
        arr.Add(new Job('e', 3, 15));

        // Function call
        Console.WriteLine("Following is maximum profit sequence of jobs");

        Job job = new Job();

        job.printJobScheduling(arr,3);
    }
}
