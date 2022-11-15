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
            while (wholeNumbers.Count < 100)
            {
                wholeNumbers.Add(random.Next(100));
            }
            PrintList(wholeNumbers);
            Console.ReadKey();
        }

        public static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
        }

        public void DeleteNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list.RemoveAll(25);
            }
        }
    }
}
