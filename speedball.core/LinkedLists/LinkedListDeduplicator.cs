using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using speedball.core.DataStructures;

namespace speedball.core.LinkedLists
{
    public static class LinkedListDeduplicator
    {
        public static Node DeleteDuplicates(Node input)
        {
            if (input == null || input.Next == null) return input;

            var counts = new Dictionary<int, bool>();
            var current = input;
            var previous = input;

            while (current != null)
            {
                if (counts.ContainsKey((int)current.Data))
                {
                    // remove current node because it is a dupe
                    previous.Next = current.Next ?? null;
                }
                else
                {
                    counts.Add((int)current.Data, true);
                    previous = current;
                }

                current = current.Next;
            }

            return input;
        }

        public static Node DeleteDuplicatesWithNoBuffer(Node input)
        {
            if (input == null) return null;

            var current = input;
            while (current != null)
            {
                var runner = current;
                while (runner.Next != null)
                {
                    if ((int)runner.Next.Data == (int)current.Data)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }

            return input;
        }

        public static void Run()
        {
            var start = LinkedListHelper.GetRandomLinkedList(10);
            Console.WriteLine("Starting list:");
            LinkedListHelper.PrintLinkedList(start);
            Console.WriteLine("");

            var end = DeleteDuplicates(start);
            Console.WriteLine("Ending list:");
            LinkedListHelper.PrintLinkedList(end);
            Console.WriteLine("");

            start = LinkedListHelper.GetRandomLinkedList(10);
            Console.WriteLine("Starting list:");
            LinkedListHelper.PrintLinkedList(start);
            Console.WriteLine("");

            var end2 = DeleteDuplicatesWithNoBuffer(start);
            Console.WriteLine("Ending list:");
            LinkedListHelper.PrintLinkedList(end2);
            Console.WriteLine("");
        }
    }
}
