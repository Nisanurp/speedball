using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class UniqueChecker
    {
        public static bool HasAllUniqueCharacters(string input)
        {
            var chars = new Dictionary<char, int>();

            foreach (var c in input)
            {
                if (!chars.ContainsKey(c)) chars[c] = 0;
                chars[c]++;
            }

            foreach(var kvp in chars)
            {
                if (kvp.Value > 1) return false;
            }

            return true;
        }

        //public static bool HasAllUniqueCharactersRecursive(string input)
        //{
        //    var output = true;

        //    for(int i = 0; i < input.Length; i++)
        //    {
        //        output = output && HasAllUniqueCharactersRecursive(input[i], input.Substring(i))
        //    }

        //    return output;
        //}

        //private static bool HasAllUniqueCharactersRecursive(char c, string input)
        //{
            
        //}

        public static void Run()
        {
            var input1 = "abcd";
            var input2 = "abad";

            var result1 = HasAllUniqueCharacters(input1);
            var result2 = HasAllUniqueCharacters(input2);

            Console.WriteLine("Input {0} returned the result {1}", input1, result1);
            Console.WriteLine("Input {0} returned the result {1}", input2, result2);
        }
    }
}
