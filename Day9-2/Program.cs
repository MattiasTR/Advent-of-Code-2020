using System;
using System.IO;
using System.Linq;

namespace Day9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").Select(s => Convert.ToInt64(s));

            var preamble = input.Take(25).ToArray();

            Int64 xmasNumber = 0;

            for (int currentNumber = preamble.Count(); currentNumber < input.Count(); currentNumber++)
            {
                xmasNumber = input.ElementAt(currentNumber);

                var numberFound = false;

                for (int outer = 0; outer < preamble.Count() - 1; outer++)
                {
                    for (int inner = outer + 1; inner < preamble.Count(); inner++)
                    {
                        if (preamble[outer] + preamble[inner] == xmasNumber)
                        {
                            numberFound = true;
                            break;
                        }
                    }

                    if (numberFound)
                        break;
                }

                if (!numberFound)
                {
                    Console.WriteLine("The number " + xmasNumber.ToString() + " cannot be calculated.");
                    break;
                }

                preamble.TakeLast(preamble.Count() - 1).ToArray().CopyTo(preamble, 0);
                preamble[preamble.Count() - 1] = xmasNumber;
            }

            bool foundSum = false;
            for(int startPos = 0; startPos < input.Count() - 1; startPos++)
            {
                for(int length = input.Count() - 1; length >= 2; length--)
                {
                    var range = input.Skip(startPos).Take(length);
                    if(range.Sum() == xmasNumber)
                    {
                        Console.WriteLine("Found contiguous numbers that sum to " + xmasNumber.ToString() + ". Lowest number is " + range.Min() + " and highest is " + range.Max() + ". Their sum is " + (range.Min() + range.Max()) + ".");
                        foundSum = true;
                        break;
                    }
                }

                if (foundSum)
                    break;
            }
        }
    }
}
