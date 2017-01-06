using System;
using System.Linq;
using System.Threading.Tasks;

namespace _2CNF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var graph = CreateGraph();
            var implication = new ImplicationGraph(6);
            implication.Parse();
            Console.Read();
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

    }
}
