using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using speedball.core.DataStructures;

namespace speedball.core.LinkedLists
{
    public static class LinkedListHelper
    {
        public static void PrintLinkedList(Node input)
        {
            Console.Write("[ ");
            while (input != null)
            {
                Console.Write("{0}", (int)input.Data);
                if (input.Next != null) Console.Write(", ");
                input = input.Next;
            }
            Console.WriteLine(" ]");
        }

        public static Node GetRandomLinkedList(int size)
        {
            var rng = new Random();
            var output = new Node(rng.Next(10));

            for (var i = 1; i < size; i++)
            {
                output.AppendToTail(rng.Next(10));   
            }

            return output;
        }

        public static Node GetNthToLast(Node head, int k)
        {
            if (k <= 0) return null;

            Node p1 = head;
            Node p2 = head;

            // advance p2 forward k nodes into the list
            for (int i = 0; i < k - 1; i++)
            {
                if (p2 == null) return null;
                p2 = p2.Next;
            }
            if (p2 == null) return null;

            // move p1 and p2 together so that when p2 hits the end, p1 will be at the kth element
            while (p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p1;
        }

        public static bool DeleteNode(Node n)
        {
            if (n == null || n.Next == null) return false;

            Node next = n.Next;
            n.Data = next.Data;
            n.Next = next.Next;
            return true;
        }

        public static Node Partition(Node node, int x)
        {
            Node beforeStart = null;
            Node beforeEnd = null;
            Node afterStart = null;
            Node afterEnd = null;

            while (node != null)
            {
                Node next = node.Next;
                node.Next = null;

                if ((int)node.Data < x)
                {
                    if (beforeStart == null)
                    {
                        beforeStart = node;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.Next = node;
                        beforeEnd = node;
                    }
                }
                else
                {
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.Next = node;
                        afterEnd = node;
                    }
                }

                node = next;
            }

            if (beforeStart == null) return afterStart;

            // merge before list and after list
            beforeEnd.Next = afterStart;
            
            return beforeStart;
        }

        //public static Node PartitionBetter(Node node, int x)
        //{
            
        //}

        public static Node AddLists(Node l1, Node l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0) return null;

            Node result = new Node(carry);

            int value = carry;
            if (l1 != null) value += (int) l1.Data;
            if (l2 != null) value += (int) l2.Data;

            result.Data = value % 10;

            if (l1 != null || l2 != null || value >= 10)
            {
                Node more = AddLists(l1 == null ? null : l1.Next, l2 == null ? null : l2.Next, value >= 10 ? 1 : 0);
                result.Next = more;
            }

            return result;
        }
    }
}
