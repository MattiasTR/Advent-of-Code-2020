using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pw = File.ReadLines("input.txt").ToList();
            int correctPWCount = 0;

            foreach(var line in pw)
            {
                var parts = line.Split(' ');
                int[] minmax = parts[0].Split('-').Select(int.Parse).ToArray();
                char letter = parts[1][0];
                
                if(parts[2].Count(c => c == letter) >= (minmax[0]) && parts[2].Count(c => c == letter) <= (minmax[1]))
                {
                    Console.WriteLine(line);
                    correctPWCount++;
                }
            }

            Console.WriteLine("Number of correct passwords: " + correctPWCount.ToString());
        }
    }
}
