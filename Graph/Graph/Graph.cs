using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphRepresentation
{
    internal class Graph
    {
        public int V; //number of vertices

        public  List<int>[] adj; //array of lists for ajacency list representation of vertices 

        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            if(!adj[v].Contains(w))
                adj[v].Add(w); // Add w to v's list.
            if(!adj[w].Contains(v))
                adj[w].Add(v); // Add v to w's list.
        }
    }
}
