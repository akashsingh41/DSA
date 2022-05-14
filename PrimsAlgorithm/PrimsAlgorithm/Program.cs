using System;

namespace PrimsAlgorithm
{
    internal class Program
    {
        static int V = 5;

        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
        }

        static int minimumKeyVertex(int[] key, bool[] mstSet)
        {

            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        static void primMST(int[,] graph)
        {
            // Array to store constructed MST
            int[] parent = new int[V];

            // Key values used to pick minimum weight edge in cut
            int[] costToReachKey = new int[V];

            // To represent set of vertices included in MST
            bool[] mstSet = new bool[V];

            // Initialize all keys as INFINITE
            for (int i = 0; i < V; i++)
            {
                costToReachKey[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Always include first 1st vertex in MST.
            // Make key 0 so that this vertex is picked as first vertex; First node is always root of MST
            costToReachKey[0] = 0;
            parent[0] = -1;

            // The MST will have V vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum key vertex from the set of vertices not yet included in MST
                int u = minimumKeyVertex(costToReachKey, mstSet);

                // Add the picked vertex to the MST Set
                mstSet[u] = true;

                // Update key value and parent index of the adjacent vertices of the picked vertex. Consider only those vertices which are not yet included in MST
                for (int v = 0; v < V; v++)

                    // graph[u][v] is non zero only for adjacent vertices of m
                    // mstSet[v] is false for vertices not yet included in MST
                    // Update the key only if graph[u][v] is smaller than key[v]
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < costToReachKey[v])
                    {
                        parent[v] = u;
                        costToReachKey[v] = graph[u, v];
                    }
            }

            // print the constructed MST
            printMST(parent, graph);
        }
        static void Main(string[] args)
        {
            /* Let us create the following graph
            2         3
        (0)--(1)-----(2)
        |      / \       |
      6| 8/      \5   |7
        | /          \   |
        (3)----------(4)
                  9 */

            int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                                     { 2, 0, 3, 8, 5 },
                                                     { 0, 3, 0, 0, 7 },
                                                     { 6, 8, 0, 0, 9 },
                                                     { 0, 5, 7, 9, 0 } };

            primMST(graph);
        }
    }
}
