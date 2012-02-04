using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class Queue
    {
        public Node First { get; set; }
        public Node Last { get; set; }

        public void Enqueue(object item)
        {
            if (First == null)
            {
                Last = new Node(item);
                First = Last;
            }
            else
            {
                Last.Next = new Node(item);
                Last = Last.Next;
            }
        }

        public object Dequeue()
        {
            if (First != null)
            {
                var item = First.Data;
                First = First.Next;
                return item;
            }

            return null;
        }
    }
}
