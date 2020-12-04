using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> file = File.ReadLines("input.txt").ToList();

            int xpos = 0;
            int trees = 0;

            for(int y = 0; y < file.Count; y++)
            {
                xpos = (y * 3) % file[y].Length;

                if(file[y][xpos] == '#')
                {
                    trees++;
                }

            }



            //for (int x = 0; x < file.Count; x += 1)
            //{
            //    StringBuilder currentRow = new StringBuilder(file[ypos]);
            //    currentRow[x % (file[0].Length - 1)] = '!';


            //    Console.WriteLine(currentRow);
            //    if (file[ypos][x % (file[0].Length -1)] == '#')
            //    {
            //        trees++;
            //    }

            //    ypos++;
            //}

            Console.WriteLine(trees.ToString() + " trees found in path.");
        }
    }
}
