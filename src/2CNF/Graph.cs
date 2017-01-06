using System;
using System.Collections.Generic;
using System.Linq;

namespace _2CNF
{
    public class Graph
    {
        private int[][] graph;
        private bool[] visited;
        private uint time;
        public Graph(int size)
        {
            graph = new int[size][];
            InitializeArrays(size);
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[size];
            }
        }

        private void InitializeArrays(int size)
        {
            visited = new bool[size];
        }

        public Graph(int[][] adjacencyMatrix)
        {
            graph = (int[][]) adjacencyMatrix.Clone();
            InitializeArrays(adjacencyMatrix.Length);
        }

        public int[][] AdjacencyMatrix => graph;

        public void AddEdge(int from, int to)
        {
            graph[from][to] = 1;
        }

        public void Print()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                Console.Write($"{i}: ");
                for (int j = 0; j < graph[i].Length; j++)
                {
                    Console.Write($"{graph[i][j]} ");
                }

                Console.WriteLine();
            }
        }


        public List<IEnumerable<int>> StronglyConnectedComponent(int startIndex)
        {
            var firstDfs = new Stack<int>(Dfs(startIndex).Reverse());
            var result = new List<IEnumerable<int>>();
            Transpose();
            ClearVisited();
            while (firstDfs.Any())
            {
                var vertex = firstDfs.Pop();
                if (!visited[vertex])
                {
                    var scc = Dfs(vertex);
                    result.Add(scc);
                }

            }

            return result;
        }

        private void ClearVisited()
        {
            for (int i = 0; i < graph.Length; i++)
            {
                visited[i] = false;
            }
        }

        private IEnumerable<int> Dfs(int startVertex)
        {
            var vertexes = new Stack<int>();
            var path = new LinkedList<int>();
            vertexes.Push(startVertex);
            while (vertexes.Any())
            {
                int vertex = vertexes.Pop();
                if (!visited[vertex])
                {
                    GetAncestors(vertex, vertexes);
                    visited[vertex] = true;
                }

                path.AddLast(vertex);

            }

            return path;
        }

        private void GetAncestors(int startVertex, Stack<int> stack)
        {
            for (int i = graph.Length - 1; i >= 0; i--)
            {
                if (graph[startVertex][i] == 1)
                {
                    stack.Push(i);
                }
            }
        }

        private void Transpose()
        {
            var transposedGraph = new int[graph.Length][];
            for (int i = 0; i < transposedGraph.Length; i++)
            {
                transposedGraph[i] = new int[graph[i].Length];
            }


            for (int i = 0; i < transposedGraph.Length; i++)
            {
                for (int j = 0; j < transposedGraph[i].Length; j++)
                {
                    transposedGraph[i][j] = graph[j][i];
                }
            }

            graph = (int[][])transposedGraph.Clone();
        }

        

    }
}