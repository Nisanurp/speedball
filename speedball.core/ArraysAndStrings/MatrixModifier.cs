using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class MatrixModifier
    {
        public static int[][] SetZeroes(int[][] matrix)
        {
            var row = new bool[matrix.Length];
            var column = new bool[matrix[0].Length];

            // store the row and column index with value 0
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            // set matrix[i][j] to 0 if either row i or column has a 0
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (row[i] || column[j]) matrix[i][j] = 0;
                }
            }

            return matrix;
        }

        public static void Run()
        {
            var size = 4;
            var start = MatrixHelper.GetRandomMatrix(size);
            Console.WriteLine("Starting matrix:");
            MatrixHelper.PrintMatrix(start);
            Console.WriteLine("");

            var end = SetZeroes(start);
            Console.WriteLine("Ending matrix:");
            MatrixHelper.PrintMatrix(end);

            Console.WriteLine("");
        }
    }
}
