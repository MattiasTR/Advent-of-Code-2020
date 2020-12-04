using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3_2
{
    class Program
    {
        static void Main(string[] args)
        {

            var steps = new List<(int columnStep, int rowStep)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            List<string> file = File.ReadLines("input-example.txt").ToList();
            int rowLength = file[0].Length;


            foreach (var stepCount in steps)
            {
                int treeCount = 0;

                for (int row = 0; row < file.Count; row++)
                {
                    if (row % stepCount.rowStep == 0)
                    {
                        int columnPos = (row * stepCount.columnStep) % rowLength;

                        if (file[row][columnPos] == '#')
                        {
                            treeCount++;
                        }
                    }
                }

                Console.WriteLine(treeCount.ToString() + " trees found.");
            }
        }
    }
}
