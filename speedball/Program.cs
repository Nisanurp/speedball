using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using speedball.core.ArraysAndStrings;
using speedball.core.BitManipulation;
using speedball.core.LinkedLists;
using speedball.core.RecursionAndDynamicProgramming;

namespace speedball
{
    class Program
    {
        static void Main(string[] args)
        {
            var option = 9;
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

                case 8:
                    BitManipulationHelper.Run();
                    break;

                case 9:
                    FibonacciHelper.Run();
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
