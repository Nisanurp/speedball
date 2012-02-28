using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.RecursionAndDynamicProgramming
{
    public static class ParenthesisHelper
    {
        private static void AddParen(List<string> list, int leftRem, int rightRem, char[] str, int count)
        {
            if (leftRem < 0 || rightRem < leftRem) return; // invalild state

            if (leftRem == 0 && rightRem == 0)  // no more parens remaining
            {
                var s = str.ToString();
                list.Add(s);
            }
            else
            {
                // add left paren, if there are any left parens remaining
                if (leftRem > 0)
                {
                    str[count] = '(';
                    AddParen(list, leftRem - 1, rightRem, str, count + 1);
                }

                // add right paren, if expression is valid
                if (rightRem > leftRem)
                {
                    str[count] = ')';
                    AddParen(list, leftRem, rightRem - 1, str, count + 1);
                }
            }
        }

        public static List<string> GenerateParenthesis(int count)
        {
            char[] str = new char[count * 2];
            List<string> list = new List<string>();
            AddParen(list, count, count, str, 0);  // pass by ref here?

            return list;
        }
    }
}
