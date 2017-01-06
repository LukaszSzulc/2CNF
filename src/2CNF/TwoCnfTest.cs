using System.Collections.Generic;
using System.Linq;

namespace _2CNF
{
    public class TwoCnfTest
    {
        private readonly List<IEnumerable<int>> _sss;
        private readonly int _size;

        public TwoCnfTest(List<IEnumerable<int>> sss, int size)
        {
            _sss = sss;
            _size = size;
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

        public IList<int> FindSolution()
        {
            return new List<int>();
        }
    }
}