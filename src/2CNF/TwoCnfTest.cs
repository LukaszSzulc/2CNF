using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2CNF
{
    public class TwoCnfTest
    {
        private readonly List<IEnumerable<int>> _sss;
        private readonly int _size;
        private bool?[] _resultVector;
        public TwoCnfTest(List<IEnumerable<int>> sss, int size)
        {
            _sss = sss;
            _size = size;
            _resultVector = new bool?[size*2];
        }

        public bool ContainsSolution()
        {
            foreach (var sss in _sss)
            {
                foreach (var vertex in sss.ToList())
                {
                    if (vertex < _size)
                    {
                        if (sss.Contains(vertex + _size))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (sss.Contains(vertex - _size))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public IEnumerable<bool?> FindSolution()
        {
            foreach (var sss in _sss)
            {
                var sssVertexList = sss.ToList();
                if (!AllParametersAreSet(sssVertexList))
                {
                    FindFirstSetParamaterAndAdjustOther(sssVertexList);
                }
                else
                {
                    MarkAsFalseAndComplementaryValuesAsTrue(sssVertexList);
                }
            }

            return _resultVector;
        }

        private bool IsNegative(int parameter) => parameter < _size;

        private bool AllParametersAreSet(IEnumerable<int> vertexes)
        {
            foreach (var vertex in vertexes)
            {
                if (_resultVector[vertex] != null)
                {
                    return false;
                }
            }

            return true;
        }

        private void MarkAsFalseAndComplementaryValuesAsTrue(IEnumerable<int> vertexes)
        {
            foreach (var vertex in vertexes)
            {
                var tmpVertex = vertex;
                _resultVector[tmpVertex] = false;
                if (!IsNegative(vertex))
                {
                    tmpVertex -= _size;
                }
                else
                {
                    tmpVertex += _size;
                }

                _resultVector[tmpVertex] = true;
            }
        }

        private void FindFirstSetParamaterAndAdjustOther(IEnumerable<int> vertexes)
        {
            var indexOfAdjustElement = 0;
            for (int i = 0; i < _resultVector.Length; i++)
            {
                if (_resultVector[i].HasValue)
                {
                    indexOfAdjustElement = i;
                    break;
                }
            }

            var adjustElementValue = _resultVector[indexOfAdjustElement];

            foreach (var vertex in vertexes)
            {
                if (_resultVector[vertex].HasValue)
                {
                    continue;
                }

                var vertexIndex = vertex;
                _resultVector[vertexIndex] = adjustElementValue.Value;
                if (!IsNegative(vertex))
                {
                    vertexIndex -= _size;
                }
                else
                {
                    vertexIndex += _size;
                }

                _resultVector[vertexIndex] = !adjustElementValue.Value;
            }
        }
    }
}