﻿using System;
using System.Collections.Generic;

// This class represents a directed graph
// using adjacency list representation
class Graph
{

	// No. of vertices
	private int V;

	//Adjacency Lists
	private List<List<int>> adj;
	private int Time;

	// Constructor
	
Graph(int v)
	{
		V = v;
		adj = new List<List<int>>(v);

		for (int i = 0; i < v; ++i)
			adj.Add(new List<int>());

		Time = 0;
	}

	// Function to add an edge into the graph
	void addEdge(int v, int w)
	{
		adj[v].Add(w);
	}

	List<List<int>> result = new List<List<int>>();
	// A recursive function that finds and prints strongly
	// connected components using DFS traversal
	// u --> The vertex to be visited next
	// disc[] --> Stores discovery times of visited vertices
	// low[] -- >> earliest visited vertex (the vertex with
	//			 minimum discovery time) that can be reached
	//			 from subtree rooted with current vertex
	// st -- >> To store all the connected ancestors (could be part
	//		 of SCC)
	// stackMember[] --> bit/index array for faster check
	//				 whether a node is in stack
	void SCCUtil(int u, int[] low, int[] disc, bool[] stackMember, Stack<int> st)
	{

		// Initialize discovery time and low value
		disc[u] = Time;
		low[u] = Time;
		Time += 1;
		stackMember[u] = true;
		st.Push(u);

		//int n;

		// Go through all vertices adjacent to this
		
		foreach(int n in adj[u])
		{
			if (disc[n] == -1)
			{
				SCCUtil(n, low, disc, stackMember, st);

				// Check if the subtree rooted with v
				// has a connection to one of the
				// ancestors of u
				// Case 1 (per above discussion on
				// Disc and Low value)
				low[u] = Math.Min(low[u], low[n]);
			}
			else if (stackMember[n] == true)
			{

				// Update low value of 'u' only if 'v' is
				// still in stack (i.e. it's a back edge,
				// not cross edge).
				// Case 2 (per above discussion on Disc
				// and Low value)
				low[u] = Math.Min(low[u], disc[n]);
			}
		}

		// head node found, pop the stack and print an SCC
		// To store stack extracted vertices
		List<int> res = new List<int>();
		int w = -1;
		if (low[u] == disc[u])
		{
			while (w != u)
			{
				w = (int)st.Pop();
                res.Add(w);
				stackMember[w] = false;
			}
            result.Add(res);
		}
	}

	// The function to do DFS traversal.
	// It uses SCCUtil()
	void SCC()
	{

		// Mark all the vertices as not visited
		// and Initialize parent and visited,
		// and ap(articulation point) arrays
		int[] disc = new int[V];
		int[] low = new int[V];
		for (int i = 0; i < V; i++)
		{
			disc[i] = -1;
			low[i] = -1;
		}

		bool[] stackMember = new bool[V];
		Stack<int> st = new Stack<int>();

		// Call the recursive helper function
		// to find articulation points
		// in DFS tree rooted with vertex 'i'
		for (int i = 0; i < V; i++)
		{
			if (disc[i] == -1)
				SCCUtil(i, low, disc,
						stackMember, st);
		}
	}

	// Driver code
	public static void Main(String[] args)
	{

		// Create a graph given in the above diagram
		Graph g1 = new Graph(5);

		g1.addEdge(1, 0);
		g1.addEdge(0, 2);
		g1.addEdge(2, 1);
		g1.addEdge(0, 3);
		g1.addEdge(3, 4);
        Console.WriteLine( "SSC in first graph ");
		g1.SCC();

		Graph g2 = new Graph(4);
		g2.addEdge(0, 1);
		g2.addEdge(1, 2);
		g2.addEdge(2, 3);
        Console.WriteLine("\nSSC in second graph ");
		g2.SCC();

		Graph g3 = new Graph(7);
		g3.addEdge(0, 1);
		g3.addEdge(1, 2);
		g3.addEdge(2, 0);
		g3.addEdge(1, 3);
		g3.addEdge(1, 4);
		g3.addEdge(1, 6);
		g3.addEdge(3, 5);
		g3.addEdge(4, 5);
        Console.WriteLine("\nSSC in third graph ");
		g3.SCC();

		Graph g4 = new Graph(11);
		g4.addEdge(0, 1);
		g4.addEdge(0, 3);
		g4.addEdge(1, 2);
		g4.addEdge(1, 4);
		g4.addEdge(2, 0);
		g4.addEdge(2, 6);
		g4.addEdge(3, 2);
		g4.addEdge(4, 5);
		g4.addEdge(4, 6);
		g4.addEdge(5, 6);
		g4.addEdge(5, 7);
		g4.addEdge(5, 8);
		g4.addEdge(5, 9);
		g4.addEdge(6, 4);
		g4.addEdge(7, 9);
		g4.addEdge(8, 9);
		g4.addEdge(9, 8);
        Console.WriteLine("\nSSC in fourth graph ");
		g4.SCC();

		Graph g5 = new Graph(5);
		g5.addEdge(0, 1);
		g5.addEdge(1, 2);
		g5.addEdge(2, 3);
		g5.addEdge(2, 4);
		g5.addEdge(3, 0);
		g5.addEdge(4, 2);
        Console.WriteLine( "\nSSC in fifth graph ");
		g5.SCC();
	}
}
