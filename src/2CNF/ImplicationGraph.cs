using System;
using System.IO;

namespace _2CNF
{
    public class ImplicationGraph
    {
        private readonly int _numberOfParameters;
        private readonly string _fileName;
        private int[][] implicationGraph;
        public ImplicationGraph(int numberOfParameters, string fileName = "2CNF.txt")
        {
            _numberOfParameters = numberOfParameters;
            _fileName = fileName;
            implicationGraph = new int[2*numberOfParameters+2][];
            for (int i = 0; i < implicationGraph.Length; i++)
            {
                implicationGraph[i] = new int[2*numberOfParameters + 2];
            }
        }


        public int[][] Parse()
        {
            using (var reader = File.OpenText(_fileName))
            {
                var conjunctionExpression = reader.ReadToEnd();
                var splitedByAndOperator = conjunctionExpression.Split('&');
                foreach (var expression in splitedByAndOperator)
                {
                    var removeBrackets = expression.Replace("(", string.Empty).Replace(")", string.Empty).Split('|');
                }

            }
            return new int[0][];
        }

    }
}