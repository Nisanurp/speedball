using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.Moderate
{
    public static class MaxFinder
    {
        public static int FindMaxSpecial(int a, int b)
        {
            var c = a - b;

            var sa = Sign(a);  // if a >= 0, then 1 else 0
            var sb = Sign(b);  // if b >= 1, then 1 else 0
            var sc = Sign(c);  // depends on whether or not a - b overflows

            // goal: define a value k which is 1 if a > b and 0 if a < b
            // if a = b, it doesn't matter what value k is

            // if a and b have different signs then k = sign(a)
            var use_sign_of_a = sa ^ sb;

            // if a and b have the same sign then k = sign(a - b)
            var use_sign_of_c = Flip(sa ^ sb);

            var k = use_sign_of_a * sa + use_sign_of_c * sc;
            var q = Flip(k);  // opposite of k

            return a * k + b * q;
        }


        // note: could overflow - a = Int.max - 2 and b = -15
        public static int FindMaxNaive(int a, int b)
        {
            var k = Sign(a - b);
            var q = Flip(k);

            return a * k + b * q;
        }

        // flips a 1 to a 0 and a 0 to a 1
        private static int Flip(int bit)
        {
            return 1 ^ bit;
        }

        // returns 1 if a is positive, and a 0 if a is negative
        private static int Sign(int a)
        {
            return Flip((a >> 31) & 0x1);
        }
    }
}
