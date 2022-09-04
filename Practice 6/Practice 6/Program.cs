using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 1 if you want to write employee record " +
                "and enter 2 if you want to read previous records: ");
            int count = int.Parse(Console.ReadLine());
            switch (count)
            {
                case 1: WriteFile(EmployeeAdd());
                    break;
                case 2: ReadFile();
                    Console.ReadKey();
                    break;
                default: Console.WriteLine("Wrong key number, enter 1 or 2");
                    break;
            }
        }

        static string EmployeeAdd()
        {
            Console.WriteLine("---------------Employees---------------");

            Console.Write("Enter employees id: ");
            int id = int.Parse(Console.ReadLine());
            DateTime recordDate = DateTime.Now;
            Console.Write("Enter employees name: ");
            string name = Console.ReadLine();
            Console.Write("Enter employes age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter employes height: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Enter employees birth date: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter employees birth place: ");
            string birthPlace = Console.ReadLine();
            

            string record = $"{id}#{recordDate}#{name}#{age}#{height}" +
                $"#{birthDate.ToString("dd.MM.yyyy")}#{birthPlace}";

            return record;
        }

        static void WriteFile(string record)
        {
            StreamWriter sw = new StreamWriter(@"d:\employee_records2.txt", true);
            using (sw)
            {
                sw.WriteLine(record);
            }
        }
        
        static void ReadFile()
        {
            using (StreamReader sr = new StreamReader(@"d:\employee_records2.txt"))
            {
                string line;
                Console.WriteLine("---------------Employees---------------");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    Console.WriteLine($"Employee {record[2]}\n" +
                        $"ID: {record[0]}\n" +
                        $"Record date: {record[1]}\n" +
                        $"Name: {record[2]}\n" +
                        $"Age: {record[3]}\n" +
                        $"Height: {record[4]}\n" +
                        $"Birth date: {record[5]}\n" +
                        $"Birth place: {record[6]}\n\n");
                }
            }
        }
    }
}
