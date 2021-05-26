using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Practice.Graph
{
    public class BfsUsingAdjacencyMatrix
    {
        //public static void Main(string[] args)
        //{
        //    var matrix = new int[][] {new[] {0, 1, 1, 0}, new[] {1, 0, 1, 0}, new[] {1, 1, 0, 1}, new[] {0, 0, 1, 1}};
        //    Bfs(matrix, 0);
        //    Console.ReadLine();
        //}

        public static void Bfs(int[][] matrix, int node)
        {
            var queue = new LinkedList<int>();
            var visitedNodes = new bool[matrix.Length];
            queue.AddLast(node);
            while (queue.Any())
            {
                var value = queue.First.Value;
                Console.WriteLine("Value=>" + value);
                queue.RemoveFirst();
                visitedNodes[value] = true;

                for (int i = value; i < value + 1; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (matrix[i][j] == 1 && visitedNodes[j] == false && !queue.Contains(j))
                        {
                            queue.AddLast(j);
                        }
                    }
                }
            }
        }
    }
}