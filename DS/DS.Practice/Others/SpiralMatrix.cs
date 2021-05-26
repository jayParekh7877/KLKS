using System;
using System.Collections.Generic;

namespace DS.Practice.Others
{
    public class SpiralMatrix
    {
        public static void Main(string[] args)
        {
            var temp = new int[][]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9},
                new[] {10, 8, 9}
            };

            var tempMatrix = new bool[][]
            {
                new[] {false, false, false},
                new[] {false, false, false},
                new[] {false, false, false}
            };

            var data = SpiralOrder(temp, tempMatrix);
            Console.ReadLine();
        }

        public static IList<int> SpiralOrder(int[][] matrix, bool[][] tempMatrix)
        {
            int i = 0;
            int j = 0;

            while (true)
            {
                MarkTheValueVisited(matrix, i, j);


                if (IsPossibleToIncreaseJ(matrix, i, j))
                {
                    j++;
                }
                else if (IsPossibleToIncreaseI(matrix, i))
                {
                }
                else if (IsPossibleToDecreaseI(matrix, i))
                {
                }
                else
                {
                    break;
                }
            }

            return new List<int>();
        }

        private static void MarkTheValueVisited(int[][] temp, int i, int j)
        {
        }

        private static bool IsPossibleToDecreaseI(int[][] matrix, int i)
        {
            throw new NotImplementedException();
        }

        private static bool IsPossibleToIncreaseI(int[][] matrix, int i)
        {
            throw new NotImplementedException();
        }

        private static bool IsPossibleToIncreaseJ(int[][] matrix, int i, int j)
        {
            if (j + 1 <= matrix[i].Length)
            {
                return true;
            }

            return false;
        }
    }
}