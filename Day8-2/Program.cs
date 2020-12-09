using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool terminatedSuccessfully = false;
            int accumulator = 0;
            int nextInstruction = 0;

            var input = File.ReadAllLines("input.txt");

            for(int insCount = 0; insCount < input.Count(i => (i.Contains("nop") || i.Contains("jmp"))); insCount++)
            {
                terminatedSuccessfully = false;
                string[] insList = new string[input.Length]; 
                input.CopyTo(insList, 0);

                bool insModifed = false;
                while (!insModifed)
                {
                    int currentIns = 0;
                    for(int thisIns = 0; thisIns < insList.Length; thisIns++)
                    //foreach(var ins in insList)
                    {
                        if(insList[thisIns].Contains("nop"))
                        {
                            if (currentIns == insCount)
                            {
                                insList[thisIns] = insList[thisIns].Replace("nop", "jmp");
                                insModifed = true;
                                break;
                            }
                            else
                            {
                                currentIns++;
                            }
                        }
                        else if(insList[thisIns].Contains("jmp"))
                        {
                            if (currentIns == insCount)
                            {
                                insList[thisIns] = insList[thisIns].Replace("jmp", "nop");
                                insModifed = true;
                                break;
                            }
                            else
                            {
                                currentIns++;
                            }
                        }
                    }
                }

                List<int> executedLines = new List<int>();
                accumulator = 0;
                nextInstruction = 0;

                while (!executedLines.Contains(nextInstruction))
                {
                    if (nextInstruction >= insList.Length)
                    {
                        // Program terminated successfully
                        terminatedSuccessfully = true;
                        break;
                    }

                    var currentInstruction = insList[nextInstruction];

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

                if (terminatedSuccessfully)
                {
                    Console.WriteLine("Program terminated successfully! Accumulator value: " + accumulator.ToString());
                }
                else
                {
                    Console.WriteLine($"Infinite loop detected on line " + nextInstruction.ToString() + " , accumulator value: " + accumulator.ToString());
                }
            }
        }
    }
}