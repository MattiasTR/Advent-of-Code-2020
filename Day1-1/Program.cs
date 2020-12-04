using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = File.ReadAllLines("input.txt").Select(int.Parse).ToList();

            for(int x = 0; x < input.Count - 1; x++)
            {
                for(int y = 1; y < input.Count; y++)
                {
                    if(input[x] + input[y] == 2020)
                    {
                        Console.WriteLine("{0} and {1} muliplied equals {2}", input[x], input[y], input[x] * input[y]);
                        return;
                    }
                }
            }

        }
    }
}
