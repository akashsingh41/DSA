using System;


namespace ShortestPathInDirectedAcyclicGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Graph g = new Graph(6);
            g.addEdge(0, 1, 5);
            g.addEdge(0, 2, 3);
            g.addEdge(1, 3, 6);
            g.addEdge(1, 2, 2);
            g.addEdge(2, 4, 4);
            g.addEdge(2, 5, 2);
            g.addEdge(2, 3, 7);
            g.addEdge(3, 4, -1);
            g.addEdge(4, 5, -2);

            int s = 1;
            Console.WriteLine("Following are shortest distances from source " + s);
            g.shortestPath(s);
        }
    }
}
