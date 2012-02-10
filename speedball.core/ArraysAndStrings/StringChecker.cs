using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class StringChecker
    {
        public static bool IsRotation(string s1, string s2)
        {
            return (s1 + s1).Contains(s2);
        }

        public static void Run()
        {
            var s1 = "waterbottle";
            var s2 = "erbottlewat";

            Console.WriteLine("Is {0} a rotation of {1}? {2}", s1, s2, IsRotation(s1, s2));

            var s3 = "waterbottle";
            var s4 = "football";

            Console.WriteLine("Is {0} a rotation of {1}? {2}", s3, s4, IsRotation(s3, s4));
        }
    }
}
