using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectingCycleInUndirectedGraph
{
    internal class Graph
    {
        private int V; // No. of vertices

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

        // Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        public bool IsCyclic()
        {
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;

            for (int u = 0; u < V; u++)
            {
                if (!visited[u])
                    if (isCyclic(u, visited, -1))
                        return true;
            }
            return false;
        }

        private bool isCyclic(int v, bool[] visited, int parent) 
        {
            visited[v] = true;

            foreach (int x in adj[v])
            {
                if (!visited[x])
                {
                    if (isCyclic(x, visited, v))
                        return true;
                }

                else
                {
                    if (x != parent)
                        return true;
                }
            }
            return false;
        }
    }
}
