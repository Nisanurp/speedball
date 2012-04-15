using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.Moderate
{
    public static class FactorialTrailingZeros
    {
        public static int Calculate(int input)
        {
            var count = 0;

            for (var i = 2; i <= input; i++)
            {
                count += CountFactorsOf5(i);
            }

            return count;
        }

        private static int CountFactorsOf5(int i)
        {
            var count = 0;
            while (i % 5 == 0)
            {
                count++;
                i /= 5;
            }

            return count;
        }
    }
}
