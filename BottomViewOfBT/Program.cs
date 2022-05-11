using System;
using System.Collections.Generic;
using BinaryTree;

namespace TopViewOfBinaryTree
{
    public class NodeDistance
    {
        public Node node;
        public int distance;
        public NodeDistance(Node n, int d)
        {
            node = n;
            distance = d;
        }
    }
    class Program
    {
        static List<int> BottomView(Node root)
        {
            if (root == null) return null;

            SortedDictionary<int, List<int>> node_collection = new SortedDictionary<int, List<int>>();
            int horizontal_distance = 0;

            // Create queue to do level order traversal. Every item of queue contains node and horizontal distance.
            Queue<NodeDistance> q = new Queue<NodeDistance>();
            q.Enqueue(new NodeDistance(root, 0));

            while (q.Count > 0)
            {
                NodeDistance nd = q.Dequeue();
                horizontal_distance = nd.distance;
                Node node = nd.node;

                if (node_collection.ContainsKey(horizontal_distance))
                {
                    node_collection[horizontal_distance].Add(node.value);
                }
                else
                    node_collection.Add(horizontal_distance, new List<int> { node.value });

                if (node.left != null)
                    q.Enqueue(new NodeDistance(node.left, horizontal_distance - 1));
                if (node.right != null)
                    q.Enqueue(new NodeDistance(node.right, horizontal_distance + 1));
            }

            List<int> result = new List<int>();
            foreach (KeyValuePair<int, List<int>> entry in node_collection)
            {
                result.Add(entry.Value[entry.Value.Count-1]);
            }
            return result;
        }
        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.left.left = new Node(4);
            tree.root.left.left.left.left = new Node(5);
            tree.root.left.left.left.left.left = new Node(6);
            tree.root.left.left.left.left.left.left = new Node(7);
            tree.root.left.left.right = new Node(8);
            tree.root.left.left.right.right = new Node(9);
            foreach (int x in BottomView(tree.root))
                Console.Write(x + " ");
        }
    }
}
