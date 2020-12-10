using System;
using System.IO;
using System.Linq;

namespace Day10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(j => Convert.ToInt32(j)).ToList();

            input.Insert(0, 0);
            var sortedInput = input.OrderBy(i => i).ToArray();

            int one = 0, three = 1;


            for (int currPos = 1; currPos < sortedInput.Length; currPos++)
            {
                var diff = sortedInput[currPos] - sortedInput[currPos - 1];
                if (diff == 1)
                {
                    one++;
                }
                else if (diff == 3)
                {
                    three++;

                }
            }

            Console.WriteLine("Number of 1 differences: " + one.ToString() + ", number of 3 differences: " + three.ToString() + ". Muliplied = " + (one * three).ToString());
        }
    }
}
