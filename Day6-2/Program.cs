using System;
using System.IO;
using System.Linq;

namespace Day6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            var groupAnswers = input.Split("\n\n");

            int total = 0;
            foreach (var answer in groupAnswers)
            {
                var personCount = answer.Split(new char[] { '\n' }).Count(c => !c.Contains('\n'));
                var cleanAnswer = answer.Replace("\n", null);
                var letterCount = cleanAnswer.GroupBy(c => c).Select(g => new { Letter = g.Key, Count = g.Count() });

                foreach(var letter in letterCount)
                {
                    if(letter.Count == personCount)
                    {
                        total++;
                    }
                }
            }

            Console.WriteLine(total);
        }
    }
}
