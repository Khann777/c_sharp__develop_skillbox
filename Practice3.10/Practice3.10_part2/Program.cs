using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3._10_part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How much cards you have?");
            int cardCount = int.Parse(Console.ReadLine());

            int cardSum = 0;
            for (int i = 0; i < cardCount; i++)
            {
                Console.WriteLine("Enter card denomination: ");
                string cardDenomination = Console.ReadLine();

                switch (cardDenomination)
                {
                    case "J":
                        cardSum += 10;
                        break;
                    case "Q":
                        cardSum += 10;
                        break;
                    case "K":
                        cardSum += 10;
                        break;
                    case "T":
                        cardSum += 10;
                        break;
                    default:
                        cardSum += int.Parse(cardDenomination);
                        break;
                }

            }
            Console.WriteLine($"Card sum of your {cardCount} cards: {cardSum}");
            Console.ReadKey();
        }
    }
}
