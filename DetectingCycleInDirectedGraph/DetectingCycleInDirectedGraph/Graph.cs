using System;
using System.Collections.Generic;
using System.Linq;

namespace DetectingCycleInDirectedGraph
{
    internal class Graph
    {
        private int V; // No. of vertices

        // Adjacency List Representation
        private List<List<int>> adj;

        // Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<List<int>>(V);
            for (int i = 0; i < v; ++i)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public void addEdge(int source, int destination)
        {
            adj[source].Add(destination);
        }

        public bool IsCyclic()
        {
            bool[] visited = new bool[V];
            bool[] recursionStack = new bool[V];
            
            for (int u = 0; u < V; u++)
            {                
                    if (isCyclic(u, visited, recursionStack))
                        return true;
            }
            return false;
        }

        private bool isCyclic(int v, bool[] visited, bool[] recursionStack)
        {
            if (recursionStack[v]) return true;
            if (visited[v]) return false; ;
            
            visited[v] = true;
            recursionStack[v] = true;
            
            foreach (int x in adj[v])
            {
                if (isCyclic(x, visited, recursionStack))                
                    return true;
                
                recursionStack[v] = false;
                return false;
            }
            return false;
        }
    }
}

