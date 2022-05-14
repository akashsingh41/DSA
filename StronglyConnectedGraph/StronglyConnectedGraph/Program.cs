using System;
using System.Collections.Generic;

namespace StronglyConnectedGraph
{
    internal class Graph
    {
        private int V;
        private List<List<int>> adj;

        public Graph(int v)
        {
            this.V = v;
            adj = new List<List<int>>();
            for (int i = 0; i < v; i++)
            {
                adj.Add(new List<int>());
            }
        }

        public void addEdge(int u, int v) { adj[u].Add(v); }

        void DFS(int v, bool[] visited)
        {
            visited[v] = true;
            foreach (int neighbour in adj[v])
            {
                if (!visited[neighbour])
                    DFS(neighbour, visited);
            }
        }
        Graph getTranspose()
        {
            Graph g = new Graph(V);
            for (int v = 0; v < V; v++)
            {
                foreach(int n in adj[v])
                // Recur for all the vertices adjacent to this vertex
                    g.adj[n].Add(v);
            }
            return g;
        }
        public bool IsSC()
        {
            bool[] visited = new bool[V];
            // Step 1: Mark all the vertices as not visited(For first DFS)
            for (int i = 0; i < V; i++)
                visited[i] = false;

            // Step 2: Do DFS traversal starting from first vertex.
            DFS(0, visited);

            // If DFS traversal doesn't visit all vertices, then return false.
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    return false;

            // Step 3: Create a reversed graph
            Graph transpose = getTranspose();

            // Step 4: Mark all the vertices as not visited (For second DFS)
            for (int i = 0; i < V; i++)
                visited[i] = false;

            // Step 5: Do DFS for reversed graph starting from first vertex. Starting Vertex must be same starting point of first DFS
            transpose.DFS(0, visited);

            // If all vertices are not visited in second DFS, then return false
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    return false;

            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g1 = new Graph(5);
            g1.addEdge(0, 1);
            g1.addEdge(1, 2);
            g1.addEdge(2, 3);
            g1.addEdge(3, 0);
            g1.addEdge(2, 4);
            g1.addEdge(4, 2);
           
            Console.WriteLine(g1.IsSC()?"Yes":"No");


            Graph g2 = new Graph(4);
            g2.addEdge(0, 1);
            g2.addEdge(1, 2);
            g2.addEdge(2, 3);
            Console.WriteLine(g2.IsSC() ? "Yes" : "No");

        }
    }
}
