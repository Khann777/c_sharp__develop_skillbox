using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers = new HashSet<int>();

            WriteNumber(numbers);
        }

        /// <summary>
        /// Writes and checks number existance in hashset
        /// </summary>
        /// <param name="numbers">Hashset to check and write in</param>
        public static void WriteNumber(HashSet<int> numbers)
        {
            while (true)
            {
                try
                {
                    Console.Write("Do you want to write number to hashset? (y/n): ");
                    string runProgramm = Console.ReadLine();
                    if (runProgramm == "" || runProgramm == "n" || runProgramm == "no")
                    {
                        return;
                    }
                    else if (runProgramm == "y" || runProgramm == "yes")
                    {
                        Console.Write("Enter number to add: ");
                        int enterNumber = int.Parse(Console.ReadLine());
                        if (numbers.Contains(enterNumber))
                        {
                            Console.WriteLine($"Number {enterNumber} already exists in hashset, try another");
                        }
                        else
                        {
                            Console.WriteLine($"Number {enterNumber} successfully added to hashset");
                            numbers.Add(enterNumber);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect line, try again");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Incorrect input, try again");
                    continue;
                }
            }
        }
    }
}