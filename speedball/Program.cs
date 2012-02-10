using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using speedball.core.ArraysAndStrings;
using speedball.core.LinkedLists;

namespace speedball
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = 7;
            switch (option)
            {
                case 1:
                    UniqueChecker.Run();
                    break;

                case 2:
                    Permutation.Run();
                    break;

                case 3:
                    StringCompression.Run();
                    break;

                case 4:
                    StringChecker.Run();
                    break;

                case 5:
                    MatrixModifier.Run();
                    break;

                case 6:
                    ImageRotation.Run();
                    break;

                case 7:
                    LinkedListDeduplicator.Run();
                    break;

                default:
                    Console.WriteLine("No option selected.");
                    break;
            }

            Console.WriteLine("Press any key to close this app.");
            Console.ReadKey();
        }
    }
}
