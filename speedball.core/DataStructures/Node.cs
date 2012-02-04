using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class Node
    {
        public Node Next = null;
        public object Data;

        public Node(object d)
        {
            Data = d;
        }

        public void AppendToTail(object d)
        {
            var end = new Node(d);
            var n = this;
            
            while (n.Next != null)
            {
                n = n.Next;
            }

            n.Next = end;
        }

        public Node DeleteNode(Node head, object d)
        {
            var n = head;

            if (n.Data == d) return head.Next;  // moved head

            while (n.Next != null)
            {
                if (n.Next.Data == d)
                {
                    n.Next = n.Next.Next;
                    return head;  // head didn't change
                }

                n = n.Next;
            }

            return head;
        }
    }
}
