using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            string[] nextInput = new string[input.Count()];
            input.CopyTo(nextInput, 0);

            bool somethingChanged = false;

            do
            {
                somethingChanged = false;

                for (int vert = 0; vert < input.Length; vert++)
                {
                    for (int horiz = 0; horiz < input[0].Length; horiz++)
                    {
                        //if (horiz == 90)
                        //    Debugger.Break();

                        if (input[vert][horiz] == 'L' && CountNeighbors(vert, horiz, input) == 0)
                        {
                            nextInput[vert] = nextInput[vert].Remove(horiz, 1).Insert(horiz, "#");
                            somethingChanged = true;
                        }
                        else if (input[vert][horiz] == '#' && CountNeighbors(vert, horiz, input) >= 4)
                        {
                            nextInput[vert] = nextInput[vert].Remove(horiz, 1).Insert(horiz, "L");
                            somethingChanged = true;
                        }

                    }
                    
                    //Console.SetCursorPosition(0, vert);
                    //Console.Write(nextInput[vert]);
                }
                nextInput.CopyTo(input, 0);
                //System.Threading.Thread.Sleep(500);

            } while (somethingChanged);

            Console.WriteLine("\n" + CountOccupiedSeats(nextInput).ToString() + " occupied seats found.");
        }

        static int CountNeighbors(int vert, int horiz, string[] input)
        {
            int count = 0;

            //string[] countArray = new string[input.Count()];
            //input.CopyTo(countArray, 0);

            for(int vertpos = vert - 1; vertpos <= vert + 1; vertpos++)
            {
                for(int horizpos = horiz - 1; horizpos <= horiz + 1; horizpos++)
                {
                    //if (vertpos == 0 && horizpos == 6)
                    //    Debugger.Break();
                    if (vertpos >= 0 && vertpos < input.Length && horizpos >= 0 && horizpos < input[0].Length && (vertpos != vert || horizpos != horiz))
                    {
                        if(input[vertpos][horizpos] == '#')
                        {
                            count++;
                            //countArray[vertpos] = countArray[vertpos].Remove(horizpos, 1).Insert(horizpos, "!");
                        }
                        else
                        {
                            //countArray[vertpos] = countArray[vertpos].Remove(horizpos, 1).Insert(horizpos, "-");
                        }
                    }
                }
            }
            //countArray[vert] = countArray[vert].Remove(horiz, 1).Insert(horiz, count.ToString());

            //for (int y = 0; y < input.Length; y++)
            //{
            //    Console.SetCursorPosition(0, y + 15);
            //    Console.Write(countArray[y]);
            //}
            //System.Threading.Thread.Sleep(500);

            return count;
        }

        static int CountOccupiedSeats(string[] input)
        {
            int count = 0;

            for(int vert = 0; vert < input.Length; vert++)
            {
                for (int horiz = 0; horiz < input[0].Length; horiz++)
                {
                    if (input[vert][horiz] == '#')
                        count++;
                }
            }

            return count;
        }
    }
}
