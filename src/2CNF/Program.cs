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
    }
}
