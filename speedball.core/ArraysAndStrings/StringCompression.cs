using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class StringCompression
    {
        public static string CompressString(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var output = new StringBuilder();

            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];
                var charCount = 1;
                var nextIndex = i + 1;

                while(nextIndex < input.Length && input[nextIndex] == c)
                {
                    charCount++;
                    nextIndex++;
                }

                output.Append(c);
                output.Append(charCount);
                i = nextIndex - 1; 
            }

            return input.Length <= output.Length ? input : output.ToString();
        }

        public static string CompressStringInPlace(string input)
        {
            // check if compression would create a longer string
            var size = CountCompression(input);
            if (size >= input.Length) return input;

            var chars = new char[size];
            var index = 0;
            var last = input[0];
            var count = 1;

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] == last)
                {
                    count++;
                }
                else
                {
                    index = SetChar(input, ref chars, last, index, count);
                    last = input[i];
                    count = 1;
                }
            }

            // update string with the last set of repeated characters
            index = SetChar(input, ref chars, last, index, count);

            return new string(chars);
        }

        private static int CountCompression(string input)
        {
            var last = input[0];
            var size = 0;
            var count = 1;

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] == last)
                {
                    count++;
                }
                else
                {
                    last = input[i];
                    size += 1 + count.ToString().Length;
                    count = 1;
                }
            }

            size += 1 + count.ToString().Length;

            return size;
        }

        private static int SetChar(string input, ref char[] chars, char c, int index, int count)
        {
            chars[index] = c;
            index++;

            // convert the count to a string then to an array of chars (?)
            var cnt = count.ToString().ToCharArray();
            foreach (var x in cnt)
            {
                chars[index] = x;
                index++;
            }

            return index;
        }

        public static void Run()
        {
            var input1 = "aabcccccaaa";
            var result1 = CompressString(input1);
            var result2 = CompressStringInPlace(input1);

            Console.WriteLine("Compressing string {0} returns a compressed string of {1}.", input1, result1);
            Console.WriteLine("Compressing string {0} in place returns a compressed string of {1}.", input1, result2);
        }
    }
}
