using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class Permutation
    {
        public static string Sort(string s)
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        public static bool IsPermutationBySorting(string s, string t)
        {
            if (s.Length != t.Length) return false;

            return Sort(s) == Sort(t);
        }

        public static bool IsPermutationByCharacterCount(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var counts = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (!counts.ContainsKey(c)) counts[c] = 0;

                counts[c]++;
            }

            foreach (var c in t)
            {
                if (!counts.ContainsKey(c)) counts[c] = 0;

                if (--counts[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Run()
        {
            var input1 = "foobar";
            var input2 = "barfoo";
            var input3 = "kungfu";

            var result1 = IsPermutationBySorting(input1, input2);
            var result2 = IsPermutationBySorting(input2, input3);

            var result3 = IsPermutationByCharacterCount(input1, input2);
            var result4 = IsPermutationByCharacterCount(input2, input3);

            Console.WriteLine("{0} is {2}a permtuation by sorting of {1}.", input1, input2, result1 ? string.Empty : "not ");
            Console.WriteLine("{0} is {2}a permtuation by sorting of {1}.", input2, input3, result2 ? string.Empty : "not ");

            Console.WriteLine("{0} is {2}a permtuation by character counting of {1}.", input1, input2, result3 ? string.Empty : "not ");
            Console.WriteLine("{0} is {2}a permtuation by character counting of {1}.", input2, input3, result4 ? string.Empty : "not ");
        }

    }
}
