using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3._10_part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter integer:");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("You entered even number!");
            }
            else
            {
                Console.WriteLine("You entered odd number");
            }
            Console.ReadKey();
        }
    }
}
