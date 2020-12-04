using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = File.ReadAllLines("input.txt").Select(int.Parse).ToList();

            for (int x = 0; x < input.Count - 2; x++)
            {
                for (int y = 1; y < input.Count - 1; y++)
                {
                    for (int z = 2; z < input.Count; z++)
                    {
                        if (input[x] + input[y] + input[z] == 2020)
                        {
                            Console.WriteLine("{0} and {1} and {2} muliplied equals {3}", input[x], input[y], input[z], input[x] * input[y] * input[z]);
                            return;
                        }
                    }
                }
            }

        }
    }
}
