using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AnagramChecker
{

    public class AnagramChecker : IAnagramChecker
    {
        readonly IConfiguration config;
        public AnagramChecker(IConfiguration config)
        {
            this.config = config;
        }

        public List<string> GetKnown(string word)
        {
            List<string> foundAnagrams = new List<string>();
            string[] dictlines = { };
            dictlines = System.IO.File.ReadAllLines(config["DictionaryPath"]);
  
            
            foreach (string line in dictlines)
            {
                if (line.Contains(word))
                {
                    string[] lineparts = line.Split("=");
                    if (lineparts[0].Trim().Equals(word))
                    {
                        foundAnagrams.Add(lineparts[1].Trim());
                    }
                    else if (lineparts[1].Trim().Equals(word))
                    {
                        foundAnagrams.Add(lineparts[0].Trim());
                    }
                }
            }
            return foundAnagrams;
        }
        public bool Check(string[] words)
        {
            if (String.Concat(words[0].OrderBy(c => c)).Equals(String.Concat(words[1].OrderBy(c => c))))
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }
        public IEnumerable<string> GetPermutations(string word)
        {
            if (word.Length == 1) return new List<string> { word };

            var permutations = from c in word
                               from p in GetPermutations(new String(word.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }
    }
}
