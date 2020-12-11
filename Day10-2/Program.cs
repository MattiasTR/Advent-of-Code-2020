using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input-small.txt").Select(j => Convert.ToInt32(j)).ToList();

            input.Insert(0, 0);
            //input.Add(input.Max() + 3);
            var sortedInput = input.OrderBy(i => i).ToArray();

            foreach(var jolt in sortedInput)
            {
                var count = sortedInput.Count(j => jolt - j < 0 && jolt - j >= -3);

                Console.WriteLine("jolt " + jolt.ToString() + " has " + count.ToString() + " possible children.");
            }
        }

        class node
        {
            int jolt;
            List<node> children;

            public node()
            {

            }
        }
    }
}
