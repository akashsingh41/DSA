using System;
using System.Collections.Generic;

namespace ShortestPathInUnweightedGraph
{
    internal class Program
    {
        // function to form edge between two vertices source and dest
        private static void addEdge(List<List<int>> adj, int i, int j)
        {
            adj[i].Add(j);
            adj[j].Add(i);
        }

        // a modified version of BFS that stores predecessor of each vertex in array pred and its distance from source in array dist
        private static bool BFS(List<List<int>> adj, int src, int dest, int v, int[] predecessor, int[] distance)
        {
            // a list to maintain list of vertices whose adjacency list is to be scanned as per normal BFS algorithm using List of int type
            List<int> neighbours = new List<int>();

            // bool array visited[] which stores the information whether ith vertex is reached at least once in the Breadth first search
            bool[] visited = new bool[v];

            // initially all vertices are unvisited so visited[i] for all i is false and as no path is yet constructed distance[i] for all i set to infinity
            for (int i = 0; i < v; i++)
            {
                visited[i] = false;
                distance[i] = int.MaxValue;
                predecessor[i] = -1;
            }

            // now source is first to be visited and distance from source to itself should be 0
            visited[src] = true;
            distance[src] = 0;
            neighbours.Add(src);

            // bfs Algorithm
            while (neighbours.Count != 0)
            {
                int u = neighbours[0];
                neighbours.RemoveAt(0);

                for (int i = 0; i < adj[u].Count; i++)
                {
                    if (visited[adj[u][i]] == false)
                    {
                        visited[adj[u][i]] = true;
                        distance[adj[u][i]] = distance[u] + 1;
                        predecessor[adj[u][i]] = u;
                        neighbours.Add(adj[u][i]);

                        // stopping condition (when we find our destination)
                        if (adj[u][i] == dest)
                            return true;
                    }
                }
            }
            return false;
        }

        private static void printShortestDistance(List<List<int>> adj, int src, int dest, int v)
        {
            // predecessor[i] array stores predecessor of i and distance array stores distance of i from src
            int[] predecessor = new int[v];
            int[] distance = new int[v];

            if (BFS(adj, src, dest, v, predecessor, distance) == false)
            {
                Console.WriteLine("Source and Destination vertex are not connected");
                return;
            }

            // List to store path
            List<int> path = new List<int>();
            int crawl = dest;
            path.Add(crawl);

            while (predecessor[crawl] != -1)
            {
                path.Add(predecessor[crawl]);
                crawl = predecessor[crawl];
            }

            // Print distance
            Console.WriteLine("Shortest path length is: " +  distance[dest]);

            // Print path
            Console.Write("Path is :");

            for (int i = path.Count - 1;
                     i >= 0; i--)
            {
                Console.Write(path[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            int v = 8; //number of vertices

            // Adjacency list for storing which vertices are connected
            List<List<int>> adj =  new List<List<int>>(v);

            for (int i = 0; i < v; i++)
            {
                adj.Add(new List<int>());
            }

            // https://cdncontribute.geeksforgeeks.org/wp-content/uploads/exampleFigure-1.png
            // Creating graph given in the above diagram. add_edge function takes adjacency list, source and destination vertex as argument and forms an edge between them.
            addEdge(adj, 0, 1);
            addEdge(adj, 0, 3);
            addEdge(adj, 1, 2);
            addEdge(adj, 3, 4);
            addEdge(adj, 3, 7);
            addEdge(adj, 4, 5);
            addEdge(adj, 4, 6);
            addEdge(adj, 4, 7);
            addEdge(adj, 5, 6);
            addEdge(adj, 6, 7);
            int source = 0, dest = 7;
            printShortestDistance(adj, source, dest, v);
        }
    }
}
