using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class ImageRotation
    {
        public static int[][] RotateImageMatrix(int[][] input, int n)
        {
            for (var layer = 0; layer < n / 2; ++layer)
            {
                var first = layer;
                var last = n - 1 - layer;

                for (var i = first; i < last; ++i)
                {
                    var offset = i = first;

                    // save top
                    var top = input[first][i];

                    // left -> top
                    input[first][i] = input[last - offset][first];

                    // bottom -> left
                    input[last - offset][first] = input[last][last - offset];

                    // right -> bottom
                    input[last][last - offset] = input[i][last];

                    // top -> right
                    input[i][last] = top;
                }
            }

            return input;
        }

        public static void Run()
        {
            var size = 4;
            var start = MatrixHelper.GetRandomMatrix(size);
            Console.WriteLine("Starting matrix:");
            MatrixHelper.PrintMatrix(start);
            Console.WriteLine("");

            var end = RotateImageMatrix(start, size);
            Console.WriteLine("Ending matrix:");
            MatrixHelper.PrintMatrix(end);

            Console.WriteLine("");
        }
    }
}
