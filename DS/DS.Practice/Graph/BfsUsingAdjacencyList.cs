using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.Practice.Graph
{
    public class BfsUsingAdjacencyList
    {
        /// <summary>
        /// refer link for understanding https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/
        ///
        /// Algorithm
        ///
        /// create array of linked list for adjacency list
        /// create queue and array of visited node
        ///
        /// add node to the queue
        /// still the queue has data iterate through queue
        /// print first value of the queue and mark that as visited
        /// put all its adjacent node to queue if they are not visited
        /// repeat the process
        ///
        ///    0----1
        ///    |    /
        ///    |  /
        ///    2----3--|
        ///         |--
        ///
        ///  3 self loop
        ///
        /// 
        /// Adjacency list
        /// 0 -> 1 2
        /// 1 -> 0 2
        /// 2 -> 0 1 3
        /// 3 -> 2 3
        /// </summary>
        private static LinkedList<int>[] _graph;

        //public static void Main(string[] args)
        //{
        //    CreateGraph(4);
        //    AddEdge(0, 1);
        //    AddEdge(0, 2);
        //    AddEdge(1, 2);
        //    AddEdge(2, 0);
        //    AddEdge(2, 3);
        //    AddEdge(3, 3);
        //    Bfs(2);
        //    Console.ReadLine();
        //}

        private static void CreateGraph(int numberOfVertices)
        {
            _graph = new LinkedList<int>[numberOfVertices];
        }

        private static void AddEdge(int vertex, int value)
        {
            if (_graph[vertex] == null)
            {
                _graph[vertex] = new LinkedList<int>();
            }

            _graph[vertex].AddLast(value);
        }

        private static void Bfs(int vertex)
        {
            var visited = new bool[_graph.Length];
            var queue = new LinkedList<int>();

            queue.AddLast(vertex);

            while (queue.Any())
            {
                var firstVertex = queue.First.Value;
                Console.WriteLine("value is =>" + firstVertex);
                visited[firstVertex] = true;
                queue.Remove(firstVertex);

                foreach (var item in _graph[firstVertex])
                {
                    if (visited[item] == false)
                    {
                        queue.AddLast(item);
                    }
                }
            }
        }
    }
}