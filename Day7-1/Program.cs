using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day7_1
{
    public enum BagType { light_red, dark_orange, bright_white, muted_yellow, shiny_gold, dark_olive, vibrant_plum, faded_blue, dotted_black };

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input-example.txt");

            var bagList = new List<Bag>();

            foreach(var bagRule in input)
            {
                var ruleParts = bagRule.Split(' ');
                var bagType = ruleParts[0] + " " + ruleParts[1];

                // Create the top bag or select it if it already exists (can it exist already?)
                Bag topBag;
                if(!bagList.Exists(b => b.Type == bagType))
                {
                    topBag = new Bag(bagType);
                    bagList.Add(topBag);
                }
                else
                {
                    topBag = bagList.Find(b => b.Type == bagType);
                }


                // Find all contained bag types and numbers
                var contents = bagRule.Split("contain")[1].Split(", ");

                if (contents.Length == 1 && contents[0].Contains("no other bags"))
                    break;

                foreach(var contentBag in contents)
                {
                    var countString = contentBag.Trim().Split(' ')[0];
                    var count = int.Parse(countString);
                    var contentBagType = contentBag.Trim().Split(' ')[1] + " " + contentBag.Trim().Split(' ')[2];

                    if(!bagList.Exists(b => b.Type == contentBagType))
                    {
                        var newBag = new Bag(contentBagType);
                        bagList.Add(newBag);
                    }

                    for (int i = 0; i < count; i++)
                    {
                        topBag.Contents.Add(bagList.Find(b => b.Type == contentBagType));
                    }
                }
            }

            var count2 = 0;
            foreach (var topBag in bagList)
            {
                //Console.WriteLine(topBag.Type);
                //PrintBags(topBag.Contents, " ");

                if(FindBagType(topBag, "shiny gold"))
                {
                    count2++;
                }
            }
            Console.WriteLine("Found " + count2.ToString() + " possible gold bag containers.");
        }

        static bool FindBagType(Bag bag, string searchstring)
        {
            return false;
        }

        static void PrintBags(List<Bag> bags, string indent)
        {
            foreach(var bag in bags)
            {
                Console.WriteLine(indent + bag.Type);
                PrintBags(bag.Contents, indent += " ");
            }
        }
    }

    public class Bag
    {
        public string Type;
        public List<Bag> Contents;

        public Bag(string BagType)
        {
            Type = BagType;
            Contents = new List<Bag>();
        }
    }
}
