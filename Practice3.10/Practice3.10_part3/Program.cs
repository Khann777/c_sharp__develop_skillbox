using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3._10_part3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number, i;

            Console.Write("Enter any number: ");
            number = Convert.ToInt32(Console.ReadLine());

            bool result = false;
            i = 2;
            while (i <= number / 2)
            {
                if (number % i == 0)
                {
                    result = true;
                    break;
                }
                i++;
            }
            if (!result)
            {
                Console.WriteLine(number + " is a Prime Number");
            }
            else
            {
                Console.WriteLine(number + " is not a Prime Number");
            }

            Console.ReadKey();
        }
    }
}
