using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using speedball.core.DataStructures;

namespace speedball.core.ScalabilityAndMemoryLimits
{
    public static class MemoryHelper
    {
        public static void PrintDuplicates(int[] array)
        {
            BitSet bs = new BitSet(32000);
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                int num0 = num - 1;  // bitset starts at 0, numbers start at 1
                if (bs.Get(num0))
                {
                    Console.WriteLine(num);
                }
                else
                {
                    bs.Set(num0);
                }
            }
        }
    }
}
