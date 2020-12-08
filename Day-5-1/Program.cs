using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Day5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input-example.txt");

            foreach(var position in input)
            {
                var row = position.Substring(0, 7);
                var column = position.Substring(7, 3);

                var test = new BitArray(8, true);
                PrintBits(test);
                //Console.WriteLine($"Before:  {Convert.ToString(test, toBase: 2),8}");

                for (int step = 0; step <= 2; step++)
                {
                    if(column[step] == 'R')
                    {
                        test.RightShift(test.OfType<bool>().Count(p => p) / 2);
                        PrintBits(test);
                    }
                    else if(column[step] == 'L')
                    {
                        test.LeftShift(test.OfType<bool>().Count(p => p) / 2);
                        PrintBits(test);
                    }
                }
                PrintBits(test);
                Console.WriteLine();
                //Console.WriteLine($"After:  {Convert.ToString(columnPos, toBase: 2),8}");
            }
        }

        static void PrintBits(BitArray printArray)
        {
            foreach(var bit in printArray)
            {
                if(Convert.ToBoolean(bit))
                    Console.Write("1");
                else
                    Console.Write("0");
            }
            Console.WriteLine();
        }
    }
}
