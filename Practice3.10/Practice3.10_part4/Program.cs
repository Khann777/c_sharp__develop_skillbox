using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3._10_part4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sequence length: ");
            int length = int.Parse(Console.ReadLine());

            int minValue = int.MaxValue;

            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter number: ");
                int number = int.Parse(Console.ReadLine());

                if (number < minValue)
                {
                    minValue = number;
                }
            }

            Console.WriteLine("Min number is: " + minValue);
            Console.ReadKey();
        }
    }
}
