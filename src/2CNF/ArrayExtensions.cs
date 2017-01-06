using System;
using System.Globalization;

namespace _2CNF
{
    public static class ArrayExtensions
    {
        public static void PrintMatrix(this int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}