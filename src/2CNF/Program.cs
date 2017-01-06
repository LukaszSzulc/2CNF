using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _2CNF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = 7;
            int startVertex = 0;
            var implication = new ImplicationGraph(size);
            var implicationGraph = implication.Parse();
            var graph = new Graph(implicationGraph);
            var result = graph.StronglyConnectedComponent(startVertex);
            PrintSss(result, size);
            var twoCnf = new TwoCnfTest(result, size);
            var solutionExists = twoCnf.ContainsSolution();
            var solution = twoCnf.FindSolution();
            int counter = 0;
            foreach (var b in solution)
            {
                Console.WriteLine(counter < size ? $"~x{counter}: {b}" : $"x{counter-size}: {b}");
                counter++;
            }
        }

        public static void PrintSss(List<IEnumerable<int>> sss, int size)
        {
            int sccCounter = 0;
            foreach (var scc in sss)
            {
                Console.Write($"Scc {++sccCounter}: ");
                foreach (var i in scc)
                {
                    Console.Write(i > size ? $"x{i - size} " : $"~x{i} ");
                }

                Console.WriteLine();
            }

        }
        private static Graph CreateGraph()
        {
            var graph = new Graph(13);
            graph.AddEdge(0,1);
            graph.AddEdge(0,4);
            graph.AddEdge(1,2);
            graph.AddEdge(1,4);
            graph.AddEdge(1,5);
            graph.AddEdge(1,8);
            graph.AddEdge(1,11);
            graph.AddEdge(2,6);
            graph.AddEdge(3,1);
            graph.AddEdge(3,7);
            graph.AddEdge(4,8);
            graph.AddEdge(5,2);
            graph.AddEdge(5,8);
            graph.AddEdge(6,5);
            graph.AddEdge(6,7);
            graph.AddEdge(6,9);
            graph.AddEdge(8,4);
            graph.AddEdge(9,5);
            graph.AddEdge(9,7);
            graph.AddEdge(10,8);
            graph.AddEdge(10,11);
            graph.AddEdge(12,3);
            graph.AddEdge(12,6);
            graph.AddEdge(12,9);
            return graph;
        }
        private static Graph CreateGraphSecond()
        {
            var graph = new Graph(6);
            graph.AddEdge(0,5);
            graph.AddEdge(0,1);
            graph.AddEdge(5,2);
            graph.AddEdge(5,1);
            graph.AddEdge(4,1);
            graph.AddEdge(4,5);
            graph.AddEdge(3,4);
            graph.AddEdge(2,1);
            graph.AddEdge(2,3);
            return graph;
        }

        private static Graph Test()
        {
            var g = new Graph(5);
            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 1);
            g.AddEdge(0, 3);
            g.AddEdge(3, 4);
            return g;
        }
    }
}
