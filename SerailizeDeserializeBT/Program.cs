using System;
using BinaryTree;
using System.Collections.Generic;

namespace SerailizeDeserializeBT
{
    class Program
    {
        static List<int> nodes = new List<int>();
        static void Serialize(Node node) //traversing the BT in preOrder and storing null pointers with '#'
        {           
            if (node == null) 
                nodes.Add(0);
            else
            {
                nodes.Add(node.value);
                Serialize(node.left);
                Serialize(node.right);
            }             
        }

        static int index=0;
        static Node Deserialize()
        {
            int x = nodes[index];
            if (x == 0)
                return null;           
            
            Node node = new Node(x);
            index++;
            node.left = Deserialize();
            index++;
            node.right = Deserialize();
            return node;
        }

        static void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.left);
                Console.Write(root.value + " ");
                InOrder(root.right);
            }
        }

        static void Main(string[] args)
        {
            BT tree = new BT();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(9);
            tree.root.right.right = new Node(8);
            tree.root.left.left.left = new Node(6);
            tree.root.left.left.right = new Node(7);
            nodes.Clear();
            Serialize(tree.root);
            foreach (int x in nodes)            
                Console.Write(x+" ");
            Console.WriteLine();
            InOrder(Deserialize());
        }

    }
}
