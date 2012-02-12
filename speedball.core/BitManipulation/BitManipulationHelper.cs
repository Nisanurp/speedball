using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.BitManipulation
{
    public static class BitManipulationHelper
    {
        /*
         * Example:
         * Inputs: N = 10000000000, M = 10011, i 2, j = 6
         * Output: N = 10001001100
         */
        public static int UpdateBits(int n, int m, int i, int j)
        {
            /*
             * Create a mask to clear bits i through j in n
             * EXAMPLE: i = 2, j = 4.  Result should be 11100011.
             * For simplicity, we'll use just 8 bits for the example.
             */

            int allOnes = ~0;  // will equal sequence of all 1s

            // 1s before position j, then 0s.  left = 11100000
            int left = allOnes << (j + 1);

            // 1s after position i.  right = 00000011
            int right = ((1 << i) - 1);

            // all 1s, except for 0s between i and j.  mask = 11100011
            int mask = left | right;

            // clear bits j through i then put m in there
            int nCleared = n & mask;  // clear bits j through i
            int mShifted = m << i;  // move m into correct position

            return nCleared | mShifted; // OR them, and we're done!
        }

        public static string PrintBinary(double num)
        {
            if (num >= 1 || num <= 0) return "ERROR";

            StringBuilder binary = new StringBuilder();
            binary.Append(".");
            while (num > 0)
            {
                // set a limit on length: 32 characters
                if (binary.Length > 32) return "ERROR";

                double r = num * 2;
                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }

            return binary.ToString();
        }

        public static string PrintBinary2(double num)
        {
            if (num >= 1 || num <= 0) return "ERROR";

            StringBuilder binary = new StringBuilder();
            double frac = 0.5;
            binary.Append(".");
            while (num > 0)
            {
                // settign a limit on length to 32 characters
                if (binary.Length > 32) return "ERROR";

                if (num >= frac)
                {
                    binary.Append(1);
                    num -= frac;
                }
                else
                {
                    binary.Append(0);
                }
                frac /= 2;
            }

            return binary.ToString();
        }

        public static int GetNext(int n)
        {
            // compute c0 and c1
            int c = n;
            int c0 = 0;
            int c1 = 1;
            while (((c & 1) == 0) && (c != 0))
            {
                c0++;
                c >>= 1;
            }

            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            // error condition
            if (c0 + c1 == 31 || c0 + c1 == 0) return -1;

            int p = c0 + c1; // position of the rightmost non-trailing zero

            n |= (1 << p); // flip the rightmost non-trailing zero
            n &= ~((1 << p) - 1); // clears all bits to the right of p
            n |= (1 << (c1 - 1)) - 1; // insert (c1 - 1) ones on the right

            return n;
        }

        public static int GetPrev(int n)
        {
            int temp = n;
            int c0 = 0;
            int c1 = 1;
            while (((temp & 1) == 1) && (temp != 0))
            {
                c1++;
                temp >>= 1;
            }

            if (temp == 0) return -1;

            while ((temp & 1) == 0 && (temp != 0))
            {
                c0++;
                temp >>= 1;
            }

            int p = c0 + c1; // position of rightmost non-trailing one
            n &= ((~0) << (p + 1)); // clears from bit p onwards

            int mask = (1 << (c1 + 1)) - 1; // sequence of (c1 + 1)
            n |= mask << (c0 - 1);

            return n;
        }

        public static int BitSwapRequired(int a, int b)
        {
            int count = 0;
            for (int c = a ^ b; c != 0; c = c >> 1)
            {
                count += c & 1;
            }

            return count;
        }

        public static int BitSwapRequiredBetter(int a, int b)
        {
            int count = 0;
            for (int c = a ^ b; c != 0; c = c & (c - 1))
            {
                count++;
            }
            return count;
        }

        public static long SwapOddEvenBits(int x)
        {
            return (((x & 0xaaaaaaaa) >> 1) | ((x & 0x55555555) << 1));
        }

        public static int FindMissing(List<int> array)
        {
            // int.integer_size - 1 corresponds to the LSB.  Start from there, and work our way through the bigger bits.
            return FindMissing(array, int.MaxValue);
        }

        public static int FindMissing(List<int> input, int column)
        {
            if (column < 0) return 0; // base case

            List<int> oneBits = new List<int>(input.Count/2);
            List<int> zeroBits = new List<int>(input.Count/2);

            foreach (int t in input)
            {
                // check the bit at column [column] in t
                // if zero, add to zero bits
                // else add to one bits
            }

            if (zeroBits.Count <= oneBits.Count)
            {
                int v = FindMissing(zeroBits, column - 1);
                return (v << 1) | 0;
            }
            else
            {
                int v = FindMissing(oneBits, column - 1);
                return (v << 1) | 1;
            }
        }

        public static void DrawLine(byte[] screen, int width, int x1, int x2, int y)
        {
            // wtf is going on here?!
            int startOffset = x1 % 8;
            int firstFullByte = x1 / 8;
            if (startOffset != 0) firstFullByte++;
            int endOffset = x2 % 8;
            int lastFullByte = x2 / 8;
            if (endOffset != 7) lastFullByte--;

            // set full bytes
            for (int b = firstFullByte; b <= lastFullByte; b++)
            {
                screen[(width / 8) * y + b] = (byte)0xFF;
            }

            // create masks for start and end of line
            byte startMask = (byte) (0xFF >> startOffset);
            byte endMask = (byte) ~(0xFF >> (endOffset + 1));

            // set start and end of line
            if ((x1 / 8) == (x2 / 8))
            {
                byte mask = (byte) (startMask & endMask);
                screen[(width / 8) * y + firstFullByte - 1] |= mask;
            }
            else
            {
                if (startOffset != 0)
                {
                    int byteNumber = (width / 8) * y + firstFullByte - 1;
                    screen[byteNumber] |= startMask;
                }
                
                if (endOffset != 0)
                {
                    int byteNumber = (width / 8) * y + lastFullByte + 1;
                    screen[byteNumber] |= endMask;
                }
            }
        }

        public static void Run()
        {
            var n = 1024;
            var m = 19;
            var i = 2;
            var j = 6;

            Console.WriteLine("N: {0}, M: {1}, I: {2}, J: {3}, Result: {4}", n, m, i, j, Convert.ToString(UpdateBits(n, m, i, j), 2));
        }
    }
}
