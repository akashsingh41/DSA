using System;
using System.Collections.Generic;
using BinarySearchTree;

namespace VerticalSumInBST
{
    class Program
    {
        static void Utility(Node n, int hd, Dictionary<int,int> sum)
        {
            if (n == null)
                return;
            
            Utility(n.left, hd - 1, sum);
            
            if (sum.ContainsKey(hd))
                sum[hd] = sum[hd] + n.value;
            else
                sum.Add(hd, n.value);

            Utility(n.right, hd + 1, sum);
        }
      
        static Dictionary<int,int> CalculateVerticalSums(Node node)
        {
            if (node == null) return null;
            Dictionary<int, int> sum = new Dictionary<int, int>();
            
            Utility(node, 0, sum);
            return sum;
        }
        static void Main(string[] args)
        {
            BST tree = new BST();
            int[] nodes = { 4, 2, 3, 1, 5 };
            foreach (int x in nodes) { tree.InsertNode(x); }

            Console.WriteLine("Following are the values of vertical sums with the positions of the columns with respect to root :");
            foreach (KeyValuePair<int, int> keyValue in CalculateVerticalSums(tree.root))            
            {
                Console.WriteLine($"Distance: {keyValue.Key}, Sum:{keyValue.Value}");
            }
        }
    }
}
