using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int i)
        {
            value = i;
        }

        public Node()
        {
        }

        public int Display()
        {
            return value;
        }
    }
}
