using System;
using System.Collections.Generic;

namespace TopologicalSorting
{
    internal class Program
    {
        static void topologicalSort(int v, bool[] visited, Stack<int> stack, List<List<int>> adj)
        {
            visited[v] = true;

            foreach (int vertex in adj[v])
            {
                if(!visited[vertex])
                    topologicalSort(vertex, visited, stack, adj);
            }
            stack.Push(v);
        }
        static void TopologicalSort(int V, List<List<int>> adj)
        {
            Stack<int> stack = new Stack<int>();
            var visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    topologicalSort(i, visited, stack, adj);
            }

            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");
            }
        }
        static void Main(string[] args)
        {
            int v = 6;
            Graph g = new Graph(v);
            g.addEdge(5, 2);
            g.addEdge(5, 0);
            g.addEdge(4, 0);
            g.addEdge(4, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 1);

            Console.WriteLine("Following is a Topological sort of the given graph");

            TopologicalSort(v, g.adj);
        }
    }
}
