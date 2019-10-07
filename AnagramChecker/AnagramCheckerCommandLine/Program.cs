using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Serilog;
namespace AnagramCheckerCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 0||(!(args[0].Equals("getKnown")) && !(args[0].Equals("check"))) || (args[0].Equals("getKnown") && args.Length != 2) || (args[0].Equals("check") && args.Length != 3))
            {
                Console.WriteLine("check your input");
                Environment.Exit(1);
            }
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();
            AnagramChecker.AnagramChecker anc = new AnagramChecker.AnagramChecker(config);
            if (args[0].Equals("check"))
            {
                string[] words = { args[1], args[2] };
                if (anc.Check(words))
                {
                    Console.WriteLine(args[1] + " and " + args[2] + " are anagrams");
                }
                else
                {
                    Console.WriteLine(args[1] + " and " + args[2] + " are no anagrams");
                }
            }
            else
            {
                List<string> foundAnagrams = anc.GetKnown(args[1]);
                if(foundAnagrams.Count == 0)
                {
                    Console.WriteLine("No Anagrams found");
                }
                else
                {
                    foreach (string a in foundAnagrams)
                    {
                        Console.WriteLine(a);
                    }
                }

            }
            
        }
    }
}
