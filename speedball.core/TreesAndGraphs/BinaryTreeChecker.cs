using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using speedball.core.DataStructures;

namespace speedball.core.TreesAndGraphs
{
    public static class BinaryTreeChecker
    {
        // Runs in O(N^2) (quadratic) time
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;  // base case

            var heightDiff = GetHeight(root.Left) - GetHeight(root.Right);
            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                return IsBalanced(root.Left) && IsBalanced(root.Right);  // recurse
            }
        }

        public static int GetHeight(TreeNode root)
        {
            if (root == null) return 0;  // base case

            return Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
        }

        public static int CheckHeight(TreeNode root)
        {
            if (root == null) return 0; // height of 0

            // check if left is balanced
            var leftHeight = CheckHeight(root.Left);
            if (leftHeight == -1) return -1; // not balanced

            // check if right is balanced
            var rightHeight = CheckHeight(root.Right);
            if (rightHeight == -1) return -1; // not balanced

            // check if current node is balanced
            var heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1) return -1;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        // Runs in O(N) time (linear) and O(log N) space
        public static bool IsBalancedLinearAlgorithm(TreeNode root)
        {
            return CheckHeight(root) != -1;
        }

        public static int lastPrinted = int.MaxValue;  // can switch to pass by reference
        public static bool CheckForBinarySearchTreeInOrder(TreeNode n)
        {
            if (n == null) return true;

            // check / recursive left
            if (!CheckForBinarySearchTreeInOrder(n.Left)) return false;

            // check current
            if (n.Data < lastPrinted) return false;
            lastPrinted = n.Data;

            // check / recursive right
            if (!CheckForBinarySearchTreeInOrder(n.Right)) return false;

            return true;  // all good!
        }

        public static bool CheckForBinarySearchTreeByMinMax(TreeNode n, int min, int max)
        {
            if (n == null) return true;

            if (n.Data <= min || n.Data > max) return false;

            if (!CheckForBinarySearchTreeByMinMax(n.Left, min, n.Data) || !CheckForBinarySearchTreeByMinMax(n.Right, n.Data, max)) return false;

            return true;
        }

        public static void Run()
        {
            
        }
    }
}
