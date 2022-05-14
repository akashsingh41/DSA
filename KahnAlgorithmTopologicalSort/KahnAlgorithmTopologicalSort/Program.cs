using System;

namespace KahnAlgorithmTopologicalSort
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(6);
            g.addEdge(5, 2);
            g.addEdge(5, 0);
            g.addEdge(4, 0);
            g.addEdge(4, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 1);
            Console.WriteLine("Following is the Topological Sort:");
            g.topologicalSort();
        }
    }
}
