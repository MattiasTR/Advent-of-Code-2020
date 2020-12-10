using System;
using System.IO;
using System.Linq;

namespace Day9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").Select(s => Convert.ToInt64(s));

            var preamble = input.Take(25).ToArray();
            //var rest = input.TakeLast(input.Count() - 25);

            for(int currentNumber = preamble.Count(); currentNumber < input.Count(); currentNumber++)
            {
                Int64 xmasNumber = input.ElementAt(currentNumber);

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

                preamble.TakeLast(preamble.Count() - 1).ToArray().CopyTo(preamble,0);
                preamble[preamble.Count() - 1] = xmasNumber;
            }
        }
    }
}
