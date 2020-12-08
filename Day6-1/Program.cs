using System;
using System.IO;
using System.Linq;

namespace Day6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            var groupAnswers = input.Split("\n\n");

            int total = 0;
            foreach(var answer in groupAnswers)
            {
                var clean = answer.Replace("\n", null);
                total += clean.Distinct().Count();
            }

            Console.WriteLine(total);
        }
    }
}
