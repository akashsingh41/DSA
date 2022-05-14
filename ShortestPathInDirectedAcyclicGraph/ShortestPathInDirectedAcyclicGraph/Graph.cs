using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInDirectedAcyclicGraph
{
    class AdjListNode
    {
        public int v;
        public int weight;
        public AdjListNode(int _v, int _w) { v = _v; weight = _w; }
        public int getV() { return v; }
        public int getWeight() { return weight; }
    }
    internal class Graph
    {
        int V;
        List<AdjListNode>[] adj;
        public Graph(int v)
        {
            V = v;
            adj = new List<AdjListNode>[V];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<AdjListNode>();
        }
        public void addEdge(int u, int v, int weight)
        {
            AdjListNode node = new AdjListNode(v, weight);
            adj[u].Add(node);// Add v to u's list
        }

        private void topologicalSort(int v, Boolean[] visited, Stack<int> stack)
        {
            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices adjacent to this vertex
            foreach (AdjListNode it in adj[v])
            {
                AdjListNode node = it;
                if (!visited[node.getV()])
                    topologicalSort(node.getV(), visited, stack);
            }

            // Push current vertex to stack which stores result
            stack.Push(v);
        }

        public void shortestPath(int s)
        {
            Stack<int> stack = new Stack<int>();    
            int[] distance = new int[V];
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++) { visited[i] = false; }

            // Call the recursive function to store Topological Sort starting from all vertices one by one
            for (int i = 0; i < V; i++)
            { 
                if (visited[i] == false)
                    topologicalSort(i, visited, stack);
            }

            // Initialize distances to all vertices as infinite and distance to source as 0
            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[s] = 0;

            // Process vertices in topological order
            while (stack.Count != 0)
            {
                // Get the next vertex from topological order
                int u = (int)stack.Pop();

                // Update distances of all adjacent vertices
                if (distance[u] != int.MaxValue)
                {
                    foreach (AdjListNode it in adj[u])
                    {
                        AdjListNode i = it;
                        if (distance[i.getV()] > distance[u] + i.getWeight())
                            distance[i.getV()] = distance[u] + i.getWeight();
                    }
                }
            }

            // Print the calculated shortest distances
            for (int i = 0; i < V; i++)
            {
                if (distance[i] == int.MaxValue)
                    Console.Write("~~~ ");
                else
                    Console.Write(distance[i] + " ");
            }

        }
    }
}
