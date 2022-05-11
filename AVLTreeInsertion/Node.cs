using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTreeInsertion
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public int height;

        public Node(int data)
        {
            this.data = data;
        }
        public Node(int t, Node l, Node r)
        {
            data = t;
            left = l;
            right = r;
            height = 1;
        }                       
    }
}
