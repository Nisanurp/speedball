using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.StacksAndQueues
{
    public static class StackHelper
    {
        public static void Run()
        {
            int n = 3;
            Tower[] towers = new Tower[n];
            for (int i = 0; i < 3; i++)
            {
                towers[i] = new Tower(i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                towers[0].Add(i);
            }
            towers[0].MoveDisks(n, towers[2], towers[1]);
        }
    }

    public class Tower
    {
        private Stack<int> disks;
        private int index;
        
        public Tower(int i)
        {
            disks = new Stack<int>();
            index = i;
        }

        public int Index()
        {
            return index;
        }

        public void Add(int d)
        {
            if (disks.Count != 0 && disks.Peek() <= d)
            {
                Console.WriteLine("{0}" + d);
            }
            else
            {
                disks.Push(d);
            }
        }

        public void MoveTopTo(Tower t)
        {
            int top = disks.Pop();
            t.Add(top);
            Console.WriteLine("Move disk {0} from {1} to {2}", top, Index(), t.Index());
        }

        public void MoveDisks(int n, Tower dest, Tower buffer)
        {
            if (n > 0)
            {
                MoveDisks(n - 1, buffer, dest);
                MoveTopTo(dest);
                buffer.MoveDisks(n - 1, dest, this);
            }
        }
    }
}
