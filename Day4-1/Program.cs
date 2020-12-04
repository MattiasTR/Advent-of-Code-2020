using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> requiredFields = new List<string>()
            {
                "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
            };

            int validPassports = 0;

            var input = File.ReadAllText("input.txt");
            var passList = input.Split("\n\n").ToList();

            foreach(var pass in passList)
            {
                var common = pass.Split(new char[] { ':', ' ', '\n' }).Intersect(requiredFields);

                if(common.Count() == requiredFields.Count)
                {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports.ToString() + " valid passports found.");
        }
    }
}
