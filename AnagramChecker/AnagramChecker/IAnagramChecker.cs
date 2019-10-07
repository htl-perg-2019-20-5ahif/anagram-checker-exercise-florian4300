using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramChecker
{
    public interface IAnagramChecker
    {
        public bool Check(string[] words);

        public List<string> GetKnown(string word);

        public IEnumerable<string> GetPermutations(string word);
    }
}
