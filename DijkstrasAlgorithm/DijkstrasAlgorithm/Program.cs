using System;
using System.Collections.Generic;

namespace DijkstrasAlgorithm
{
    internal class Program
    {
        static int minimumDistance(int[] distance,bool[] spSet, int V)
        {
            int i = 0;
            int min = int.MaxValue;
            int min_v = -1;
            while (i < V)
            {
                if(distance[i]<=min && spSet[i] == false)
                { 
                    min = distance[i];
                    min_v = i;
                }                
                i++;
            }
            return min_v;
        }
        static List<int> dijkstraAlgo(int V, ref List<List<int>> adj, int S)
        {
            bool[] spSet = new bool[V];
            int[] shortestPath=new int[V];
            int[] distance = new int[V];
            for (int i = 0; i < V; i++) 
                distance[i] = int.MaxValue;

            distance[S] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = minimumDistance(distance, spSet, V);
                spSet[u] = true;
                for (int v = 0; v < V; v++)
                {
                    if(!spSet[v] && adj[u][v] !=0 &&distance[u]!= int.MaxValue &&  distance[u]+adj[u][v]<distance[v])
                        distance[v] = distance[u]+adj[u][v];
                }
            }
            return new List<int>(distance);
        }
        static void Main(string[] args)
        {
            List<List<int>> graph = new List<List<int>>
            {  
                new List<int>(){ 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                new List<int>(){ 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                new List<int>(){ 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                new List<int>() { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                new List<int>()  { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                new List<int>() { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                new List<int>() { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                new List<int>(){ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                new List<int>() { 0, 0, 2, 0, 0, 0, 6, 7, 0 } 
            };

            Console.WriteLine("Shortest path to every node: (Dijkstra's algorithm)");
            List<int> result = dijkstraAlgo(9, ref graph, 0);
            for(int i= 0;i<graph.Count; i++)
            {
                Console.WriteLine($"{i} => {result[i]}");
            }
        }
    }
}
