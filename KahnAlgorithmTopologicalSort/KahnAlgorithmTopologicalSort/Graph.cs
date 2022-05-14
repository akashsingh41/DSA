using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahnAlgorithmTopologicalSort
{
        class Graph
        {
            
            int V;

            List<List<int>> adj;
            
            public Graph(int V)
            {
                this.V = V;
                adj = new List<List<int>>(V);
                for (int i = 0; i < V; i++)
                    adj.Add(new List<int>());
            }
            
            public void addEdge(int u, int v)
            {
                adj[u].Add(v);
            }
            
            // prints a Topological Sort of the complete graph
            public void topologicalSort()
            {
                // Create a array to store indegrees of all ertices. Initialize all indegrees as 0.
                int[] indegree = new int[V];

                // Traverse adjacency lists to fill indegrees of vertices. This step takes O(V+E) time
                for (int i = 0; i < V; i++)
                {
                    List<int> temp = (List<int>)adj[i];
                    foreach(int node in temp)
                    {
                        indegree[node]++;
                    }
                }

                // Create a queue and enqueue all vertices with indegree 0
                Queue<int> q = new Queue<int>();
                for (int i = 0; i < V; i++)
                {
                    if (indegree[i] == 0)
                        q.Enqueue(i);
                }

                // Initialize count of visited vertices
                int count = 0;

            // Create a list to store result (A topological ordering of the vertices)
            List<int> topOrder = new List<int>();
                while (q.Count > 0)
                {
                    // Extract front of queue (or perform dequeue) and add it to topological order
                    int u = q.Dequeue();
                    topOrder.Add(u);

                    // Iterate through all its neighbouring nodes of dequeued node u and decrease their in-degree by 1
                    foreach (int node in adj[u])
                    {
                        // If in-degree becomes zero,
                        // add it to queue
                        if (--indegree[node] == 0)
                            q.Enqueue(node);
                    }
                    count++;
                }

                // Check if there was a cycle
                if (count != V)
                {
                Console.WriteLine(
                        "There exists a cycle in the graph");
                    return;
                }

                // Print topological order
                foreach (int i in topOrder)
                {
                Console.Write(i + " ");
                }
            }
        }
    
}
