using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.Moderate
{
    public static class NumberSwapper
    {
        public static void SwapNumbersInPlace(int a, int b)
        {
            // hint: imagine the numbers a and b on a number line
            // example for a = 9, b = 4
            a = a - b;  // a = 9 - 4 = 5
            b = a + b;  // b = 5 + 4 = 9
            a = b - a;  // a = 9 - 5 = 4

            Console.WriteLine("a: {0}", a);
            Console.WriteLine("b: {0}", b);
        }

        public static void SwapNumbersInPlaceViaBitManipulation(int a, int b)
        {
            // benefit, this works with data types other than ints
            // example for a = 101 (in binary) and b = 110
            a = a ^ b;  // a = 101 ^ 110 = 011
            b = a ^ b;  // b = 011 ^ 110 = 101
            a = a ^ b;  // a = 011 ^ 101 = 110

            Console.WriteLine("a: {0}", a);
            Console.WriteLine("b: {0}", b);
        }
    }
}
