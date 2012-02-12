using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.RecursionAndDynamicProgramming
{
    public class StaircaseSolver
    {
        // runtime on this sucks... exponential O(3^n)
        public static int CountWays(int steps)
        {
            if (steps < 0) return 0;

            if (steps == 0) return 1;

            return CountWays(steps - 1) + CountWays(steps - 2) + CountWays(steps - 3);
        }

        public static int CountWaysDP(int steps, int[] map)
        {
            if (steps < 0) return 0;
            if (steps == 0) return 1;
            if (map[steps] > -1) return map[steps];

            map[steps] = CountWaysDP(steps - 1, map) + CountWaysDP(steps - 2, map) + CountWaysDP(steps - 3, map);

            return map[steps];
        }

        public static void Run()
        {
            
        }
    }
}
