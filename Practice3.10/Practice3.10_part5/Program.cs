using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3._10_part5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Max number range");
            int range = int.Parse(Console.ReadLine());

            Random rnd = new Random();
            int randomNumber = rnd.Next(0, range);

            while (true)
            {
                Console.Write("Enter your number: ");

                string enterNumber = Console.ReadLine();
                if (enterNumber == "")
                {
                    Console.WriteLine($"Unfortunatelly you have not guessed the right number, it is {randomNumber}\n" +
                        $"press Enter to exit");
                    break;
                }
                else
                {
                    int number = int.Parse(enterNumber);
                    if (number < randomNumber)
                    {
                        Console.WriteLine("Your number is less than expected, try again");
                    }
                    if (number > randomNumber)
                    {
                        Console.WriteLine("Your number is bigger than expected, try again");
                    }
                    if (number == randomNumber)
                    {
                        Console.WriteLine($"Congratulations you have guessed the right number, it is: {randomNumber}\n" +
                            $"Press Enter to exit.");
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
