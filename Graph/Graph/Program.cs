using System;

namespace GraphRepresentation
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);


                for (int i = 0; i < g.adj.Length; i++)
                {
                    Console.WriteLine("\nAdjacency list of vertex " + i);
                    Console.Write("head");
                    foreach (var item in g.adj[i])
                    {
                        Console.Write(" -> " + item);
                    }
                    Console.WriteLine();
                }
            }
    }
}
