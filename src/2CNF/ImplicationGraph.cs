using System;
using System.IO;
using System.Linq;

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
            implicationGraph = new int[2*numberOfParameters][];
            for (int i = 0; i < implicationGraph.Length; i++)
            {
                implicationGraph[i] = new int[2*numberOfParameters];
            }
        }


        public int[][] Parse()
        {
            using (var reader = File.OpenText(_fileName))
            {
                var conjunctionExpression = reader.ReadToEnd();
                Console.WriteLine(conjunctionExpression);
                var splitedByAndOperator = conjunctionExpression.Split('&');
                foreach (var expression in splitedByAndOperator)
                {
                    var removeBrackets = expression.Replace("(", string.Empty).Replace(")", string.Empty).Split('|');
                    var firstExpressionMember = removeBrackets.First();
                    var secondExpressionMember = removeBrackets.Last();
                    var firstExpressionMemberIndex = int.Parse(firstExpressionMember.Replace("x", string.Empty));
                    int secondExpressionMemberIndex;
                    if (secondExpressionMember.StartsWith("~"))
                    {
                        secondExpressionMemberIndex = int.Parse(secondExpressionMember.Replace("~", string.Empty).Replace("x", string.Empty));
                        implicationGraph[firstExpressionMemberIndex][secondExpressionMemberIndex] = 1;
                        implicationGraph[secondExpressionMemberIndex+_numberOfParameters][firstExpressionMemberIndex + _numberOfParameters] = 1;
                    }
                    else
                    {
                        secondExpressionMemberIndex = int.Parse(secondExpressionMember.Replace("x", string.Empty));
                        implicationGraph[firstExpressionMemberIndex][secondExpressionMemberIndex+_numberOfParameters] = 1;
                        implicationGraph[secondExpressionMemberIndex][firstExpressionMemberIndex+_numberOfParameters] = 1;
                    }

                }

            }

            return implicationGraph;
        }

    }
}