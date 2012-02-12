using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using speedball.core.DataStructures;

namespace speedball.core.TreesAndGraphs
{
    public static class BinarySearchTreeCreator
    {
        public static TreeNode CreateMinimalBST(int[] input, int start, int end)
        {
            if (end < start) return null;

            int mid = (start + end)/2;
            TreeNode n = new TreeNode(input[mid]);
            n.Left = CreateMinimalBST(input, start, mid - 1);
            n.Right = CreateMinimalBST(input, mid + 1, end);
            return n;
        }

        public static TreeNode CreateMinimalBST(int[] input)
        {
            return CreateMinimalBST(input, 0, input.Length - 1);
        }


        // Depth First Options
        public static List<LinkedList<TreeNode>> CreateLevelLinkedList(TreeNode root)
        {
            var output = new List<LinkedList<TreeNode>>();
            CreateLevelLinkedList(root, output, 0);  // might need to pass by reference

            return output;
        }

        private static void CreateLevelLinkedList(TreeNode root, List<LinkedList<TreeNode>> lists, int level)
        {
            if (root == null) return;  // base case

            LinkedList<TreeNode> list;
            if (lists.Count == level)  // level not contained in the list yet
            {
                /*
                 * Levels are always traversed in order.  So, if this is the first time we've visited level i,
                 * we must have seen levels 0 through i - 1.  We can therefore safely add the level at the end
                 */
                list = new LinkedList<TreeNode>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }

            list.AddLast(root);
            CreateLevelLinkedList(root.Left, lists, level + 1);
            CreateLevelLinkedList(root.Right, lists, level + 1);
        }

        // Breadth First Options

        public static List<LinkedList<TreeNode>> CreateLevelLinkedListBreadthFirst(TreeNode root)
        {
            var result = new List<LinkedList<TreeNode>>();

            // visit the root
            var current = new LinkedList<TreeNode>();

            if (root != null) current.AddLast(root);

            while (current.Count > 0)
            {
                result.Add(current);  // add the previous level
                LinkedList<TreeNode> parents = current; // go to the next level
                current = new LinkedList<TreeNode>();
                foreach (var parent in parents)
                {
                    // visit the children
                    if (parent.Left != null) current.AddLast(parent.Left);
                    if (parent.Right != null) current.AddLast(parent.Right);
                }
            }

            return result;
        }
    }
}
