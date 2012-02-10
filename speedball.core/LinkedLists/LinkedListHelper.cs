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
    }
}
