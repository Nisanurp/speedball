using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.RecursionAndDynamicProgramming
{
    public static class StringHelper
    {
        // runs in O(n!) time since there are n! permutations... cannot do better than this.
        public static List<string> GetPermutations(string input)
        {
            if (input == null) return null;

            List<string> permutations = new List<string>();
            if (input.Length == 0)  // base case
            {
                permutations.Add("");
                return permutations;
            }

            char first = input[0];  // get first char
            string remainder = input.Substring(1);  // remove the 1st char
            List<string> words = GetPermutations(remainder);
            foreach(var word in words)
            {
                for(int j = 0; j <= word.Length; j++)
                {
                    string s = InsertCharAt(word, first, j);
                    permutations.Add(s);
                }
            }

            return permutations;
        }

        private static string InsertCharAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end;
        }
    }
}
