using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4_2
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

            foreach (var pass in passList)
            {
                var common = pass.Split(new char[] { ':', ' ', '\n' });

                if (common.Intersect(requiredFields).ToList().Count() == requiredFields.Count)
                {
                    bool validationOK = true;

                    for (var field = 0; field < common.Count(); field+=2)
                    {
                        switch(common[field])
                        {
                            case "byr":
                                if (int.Parse(common[field + 1]) < 1920 || int.Parse(common[field + 1]) > 2002)
                                    validationOK = false;
                                break;
                            case "iyr":
                                if (int.Parse(common[field + 1]) < 2010 || int.Parse(common[field + 1]) > 2020)
                                    validationOK = false;
                                break;
                            case "eyr":
                                if (int.Parse(common[field + 1]) < 2020 || int.Parse(common[field + 1]) > 2030)
                                    validationOK = false;
                                break;
                            case "hgt":
                                int min = int.MaxValue, max = int.MinValue;
                                if (common[field + 1].Contains("in"))
                                {
                                    min = 59; max = 76;
                                }
                                else if(common[field + 1].Contains("cm"))
                                {
                                    min = 150; max = 193;
                                }
                                
                                if (int.Parse(common[field + 1].TrimEnd(new char[] { 'c', 'm', 'i', 'n' })) < min || int.Parse(common[field + 1].TrimEnd(new char[] { 'c', 'm', 'i', 'n' })) > max)
                                    validationOK = false;
                                break;
                            case "hcl":
                                if (!new Regex("^[#][a-f0-9]{6}$").IsMatch(common[field +1]))
                                {
                                    validationOK = false;
                                }
                                break;
                            case "ecl":
                                if (!new Regex("^(amb|blu|brn|gry|grn|hzl|oth)$").IsMatch(common[field + 1]))
                                {
                                    validationOK = false;
                                }
                                break;
                            case "pid":
                                if (!new Regex("^[0-9]{9}$").IsMatch(common[field + 1]))
                                {
                                    validationOK = false;
                                }
                                break;
                        }

                        if (!validationOK)
                            break;
                    }
                    if (validationOK)
                    {
                        validPassports++;
                        //Console.WriteLine(pass.Replace('\n', ' ') + " is assumed valid.");
                    }
                }
            }

            Console.WriteLine(validPassports.ToString() + " valid passports found.");
        }
    }
}
