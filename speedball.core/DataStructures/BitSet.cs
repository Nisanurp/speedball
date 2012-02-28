using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.DataStructures
{
    public class BitSet
    {
        private int[] bitset;

        public BitSet(int size)
        {
            bitset = new int[size >> 5];  // divide by 32
        }

        public bool Get(int pos)
        {
            int wordNumber = (pos >> 5);  // divide by 32
            int bitNumber = (pos & 0x1F);  // mod 32
            return (bitset[wordNumber] & (1 << bitNumber)) != 0;
        }

        public void Set(int pos)
        {
            int wordNumber = (pos >> 5);  // divide by 32
            int bitNumber = (pos & 0x1F);  // mod 32
            bitset[wordNumber] |= 1 << bitNumber;
        }
    }
}
