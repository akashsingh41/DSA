using System;
using System.Collections.Generic;

namespace DepthFirstSerach
{
    public class Graph
    {
        private int V; // No. of vertices

        // Array of lists for
        // Adjacency List Representation
        private List<int>[] adj;

        // Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        // Function to Add an edge into the graph
        public void AddEdge(int v, int w)
        {
            if(!adj[v].Contains(w))
                adj[v].Add(w); // Add w to v's list.

            if (!adj[w].Contains(v))
                adj[w].Add(v); // Add v to w's list.
        }

        private void depthFirstSearch(int v, int[] visited)
        {
            visited[v] = 1;
            Console.Write(v+" ");
            foreach (int neighbour in adj[v])
            {
                if (visited[neighbour] == 0)
                    depthFirstSearch(neighbour, visited);
            }
        }
        public void DFS(int v) 
        {
            int[] visited = new int[V];
            for (int x = 0; x < V; x++)
            { visited[x] = 0; }

            for (int x = 0; x < V; x++)
            {
                if (visited[x] == 0)
                    depthFirstSearch(x, visited);
            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            g.DFS(0);
        }
    }
}
