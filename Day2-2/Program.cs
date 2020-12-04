using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pw = File.ReadLines("input.txt").ToList();
            int correctPWCount = 0;

            foreach (var line in pw)
            {
                var parts = line.Split(' ');
                int[] minmax = parts[0].Split('-').Select(int.Parse).ToArray();
                char letter = parts[1][0];

                if((parts[2].Length >= minmax[1]) && ((parts[2][minmax[0] - 1] == letter) ^ (parts[2][minmax[1] - 1] == letter)))
                {
                    Console.WriteLine(line);
                    correctPWCount++;
                }
            }

            Console.WriteLine("Number of correct passwords: " + correctPWCount.ToString());
        }
    }
}
