using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSorting
{
    internal class Graph
    {
        public int V; // No. of vertices

        // Adjacency List Representation
        public List<List<int>> adj;

        // Constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
        }        
    }
}

