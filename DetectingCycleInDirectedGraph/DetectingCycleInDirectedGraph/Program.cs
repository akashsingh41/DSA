using System;

namespace DetectingCycleInDirectedGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(1, 2);
            graph.addEdge(2, 0);
            graph.addEdge(2, 3);
            graph.addEdge(3, 3);

            if (graph.IsCyclic())
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't "
                                        + "contain cycle");
        }
    }
}
