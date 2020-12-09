using System;
using System.Collections.Generic;
using System.IO;

namespace Day8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input-example.txt");
            List<int> executedLines = new List<int>();
            int accumulator = 0;
            int nextInstruction = 0;

            while (!executedLines.Contains(nextInstruction))
            {
                var currentInstruction = input[nextInstruction];

                switch (currentInstruction.Split(' ')[0])
                {
                    case "acc":
                        accumulator += int.Parse(currentInstruction.Split(' ')[1]);
                        executedLines.Add(nextInstruction);
                        nextInstruction++;
                        break;
                    case "jmp":
                        executedLines.Add(nextInstruction);
                        nextInstruction += int.Parse(currentInstruction.Split(' ')[1]);
                        break;
                    case "nop":
                        executedLines.Add(nextInstruction);
                        nextInstruction++;
                        break;
                }
            }

            Console.WriteLine($"Infinite loop detected on line " + nextInstruction.ToString() + " , accumulator value: " + accumulator.ToString());
        }
    }
}