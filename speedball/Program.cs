using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using speedball.core.ArraysAndStrings;

namespace speedball
{
    class Program
    {
        static void Main(string[] args)
        {
            Temp();
            var option = 2;
            switch (option)
            {
                case 1:
                    UniqueChecker.Run();
                    break;

                case 2:
                    Permutation.Run();
                    break;

                default:
                    Console.WriteLine("No option selected.");
                    break;
            }

            Console.WriteLine("Press any key to close this app.");
            Console.ReadKey();
        }

        private static void Temp()
        {
            var foo = new Dictionary<int, int>();
            var bar = new StringBuilder();
            foo.Add(1,2);
        }
    }
}
