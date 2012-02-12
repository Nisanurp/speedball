using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Data { get; set; }

        public TreeNode() { }

        public TreeNode(int data)
        {
            Data = data;
        }
    }
}
