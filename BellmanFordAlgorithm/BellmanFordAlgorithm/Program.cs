using System;

namespace BellmanFordAlgorithm
{
    public class Graph
    {
        // A class to represent a weighted edge in graph
        public class Edge
        {
            public int src, dest, weight;
            public Edge()
            {
                src = dest = weight = 0;
            }
        }

        public int V, E;
        public Edge[] edge;

        // Creates a graph with V vertices and E edges
        public Graph(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[e];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        public void BellmanFord(Graph graph, int src)
        {
            int V = graph.V, E = graph.E;
            int[] dist = new int[V];

            // Step 1: Initialize distances from src to all other vertices as INFINITE
            for (int i = 0; i < V; ++i)
                dist[i] = int.MaxValue;
            dist[src] = 0;

            // Step 2: Relax all edges |V| - 1 times. A simple shortest path from src to any other vertex can have at-most |V| - 1 edges
            for (int i = 1; i < V; ++i)
            {
                for (int j = 0; j < E; ++j)
                {
                    int u = graph.edge[j].src;
                    int v = graph.edge[j].dest;
                    int weight = graph.edge[j].weight;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                        dist[v] = dist[u] + weight;
                }
            }

            // Step 3: check for negative-weight cycles. The above step guarantees shortest distances if graph doesn't contain negative weight cycle. If we get a shorter path, then there is a cycle.
            for (int j = 0; j < E; ++j)
            {
                int u = graph.edge[j].src;
                int v = graph.edge[j].dest;
                int weight = graph.edge[j].weight;
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    Console.WriteLine("Graph contains negative weight cycle");
                    return;
                }
            }
            printArr(dist, V);
        }

        void printArr(int[] dist, int V)
        {
            Console.WriteLine("Vertex \t Distance from Source");
            for (int i = 0; i < V; ++i)
                Console.WriteLine(i + "\t\t" + dist[i]);
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            int V = 5; // Number of vertices in graph
            int E = 8; // Number of edges in graph

            Graph graph = new Graph(V, E);


            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = -1;


            graph.edge[1].src = 0;
            graph.edge[1].dest = 2;
            graph.edge[1].weight = 4;


            graph.edge[2].src = 1;
            graph.edge[2].dest = 2;
            graph.edge[2].weight = 3;


            graph.edge[3].src = 1;
            graph.edge[3].dest = 3;
            graph.edge[3].weight = 2;


            graph.edge[4].src = 1;
            graph.edge[4].dest = 4;
            graph.edge[4].weight = 2;


            graph.edge[5].src = 3;
            graph.edge[5].dest = 2;
            graph.edge[5].weight = 5;


            graph.edge[6].src = 3;
            graph.edge[6].dest = 1;
            graph.edge[6].weight = 1;


            graph.edge[7].src = 4;
            graph.edge[7].dest = 3;
            graph.edge[7].weight = -3;

            graph.BellmanFord(graph, 0);
        }
    }
}
