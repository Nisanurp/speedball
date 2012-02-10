using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace speedball.core.ArraysAndStrings
{
    public static class MatrixHelper
    {
        public static int[][] GetRandomMatrix(int size)
        {
            var rng = new Random();
            var output = new int[size][];

            for (var i = 0; i < output.Length; i++)
            {
                output[i] = new int[size];
                for (var j = 0; j < output[0].Length; j++)
                {
                    output[i][j] = rng.Next(10);
                }
            }

            return output;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                Console.Write("[ ");
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write("{0}", matrix[i][j]);
                    if (j != matrix[0].Length - 1) Console.Write(", ");
                }
                Console.WriteLine(" ]");
            }
        }
    }
}
