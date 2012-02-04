using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class Stack
    {
        public Node Top;

        public object Pop()
        {
            if (Top != null)
            {
                var item = Top.Data;
                Top = Top.Next;

                return item;
            }

            return null;
        }

        public void Push(object item)
        {
            var t = new Node(item);
            t.Next = Top;
            Top = t;
        }

        public object Peek()
        {
            return Top.Data;
        }
    }
}
