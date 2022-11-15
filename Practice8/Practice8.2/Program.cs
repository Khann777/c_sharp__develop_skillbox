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
            Dictionary<int, string> phoneBook = new Dictionary<int, string>();

            WritePhones(phoneBook);
            SearchPhone(phoneBook);
        }

        /// <summary>
        /// Writes phone numbers to dictionary
        /// </summary>
        /// <param name="phones">Dictionary to write in</param>
        public static void WritePhones(Dictionary<int, string> phones)
        {
            while (true)
            {
                Console.Write("Do you want to write phone number? (y/n): ");
                string runProgramm = Console.ReadLine();
                if (runProgramm == "" || runProgramm == "n" || runProgramm == "no")
                {
                    return;
                }
                else if(runProgramm == "y" || runProgramm == "yes")
                {
                    Console.Write("Write phone number: ");
                    int phoneNumber = int.Parse(Console.ReadLine());
                    Console.Write("Write name: ");
                    string name = Console.ReadLine();
                    phones.Add(phoneNumber, name);
                }
                else
                {
                    Console.WriteLine("Incorrect line, try again");
                }
            }
        }

        /// <summary>
        /// Searches for phone numbers in dictionary
        /// </summary>
        /// <param name="phones">dictionary to search in</param>
        public static void SearchPhone(Dictionary<int, string> phones)
        {
            while (true)
            {
                Console.Write("Do you want to search for phone number? (y/n): ");
                string runProgramm = Console.ReadLine();
                if (runProgramm == "" || runProgramm == "n" || runProgramm == "no")
                {
                    return;
                }
                else if (runProgramm == "y" || runProgramm == "yes")
                {
                    try
                    {
                        Console.Write("Write phone number: ");
                        int phoneNumber = int.Parse(Console.ReadLine());

                        string value = "";
                        if (phones.TryGetValue(phoneNumber, out value))
                        {
                            Console.WriteLine($"Phone number = \"{phoneNumber}\", name is {value}.");
                        }
                        else
                        {
                            Console.WriteLine($"Phone number = \"{phoneNumber}\" is not found.");
                        }
                    }
                    catch (System.FormatException)
                    {
                        return;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Incorrect line, try again");
                }
            }
        }
    }
}