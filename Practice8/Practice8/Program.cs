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
            Random random = new Random();
            List<int> wholeNumbers = new List<int>();

            int i = 0;
            while (i < 100)
            {
                wholeNumbers.Add(random.Next(100));
                i++;
            }

            PrintNumbers(wholeNumbers);
            Console.ReadKey();

            DeleteFromList(wholeNumbers);
            PrintNumbers(wholeNumbers);
            Console.ReadKey();

        }

        /// <summary>
        /// Prints all numbers in list and next line prints count
        /// </summary>
        /// <param name="list">Collection to print</param>
        public static void PrintNumbers(List<int> list)
        {
            foreach (int num in list)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine($"\nList count: {list.Count}");
        }

        /// <summary>
        /// Deletes numbers from list than are more than 25 and less than 50
        /// </summary>
        /// <param name="list">Collection to delete range</param>
        public static void DeleteFromList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int num = list[i];
                list.RemoveAll(num => num > 25 && num < 50);
            }
        }
    }
}