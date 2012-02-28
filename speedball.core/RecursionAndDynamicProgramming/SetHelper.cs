using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.RecursionAndDynamicProgramming
{
    public static class SetHelper
    {
        // executes in O(2^n) time and space, which is the best we can do.  slight optimization by implementing iteratively
        public static List<List<int>> GetAllSubsets(List<int> set, int index)
        {
            List<List<int>> allSubsets;
            if (set.Count == index) // base case - add empty set
            {
                allSubsets = new List<List<int>>();
                allSubsets.Add(new List<int>());  // empty set
            }
            else
            {
                allSubsets = GetAllSubsets(set, index + 1);
                int item = set[index];
                List<List<int>> moreSubsets = new List<List<int>>();
                foreach (var subset in allSubsets)
                {
                    List<int> newSubset = new List<int>();
                    newSubset.AddRange(subset);
                    newSubset.Add(item);
                    moreSubsets.Add(newSubset);
                }
                allSubsets.AddRange(moreSubsets);
            }

            return allSubsets;
        }

        public static List<List<int>> GetAllSubsets2(List<int> set)
        {
            var allSubsets = new List<List<int>>();
            var max = 1 << set.Count;  // compute 2^n
            for (var k = 0; k < max; k++)
            {
                var subset = ConvertIntToSet(k, set);
                allSubsets.Add(subset);
            }

            return allSubsets;
        }

        private static List<int> ConvertIntToSet(int x, List<int> set)
        {
            var subset = new List<int>();
            var index = 0;
            for (var k = x; k > 0; k >>= 1)
            {
                if ((k & 1) == 1) subset.Add(set[index]);
                index++;
            }

            return subset;
        }
    }
}
