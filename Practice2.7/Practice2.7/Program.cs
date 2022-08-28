using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Alex Smith";
            byte age = 17;
            string email = "alexs17@gmail.com";
            double programmingScore = 78.8;
            double mathScore = 90;
            double physicsScore = 60.3;
            double totalScore = programmingScore + mathScore + physicsScore;
            double medianScore = totalScore / 3;

            Console.WriteLine(
                $"Name: {fullName}\n" +
                $"Age: {age}\n" +
                $"E-mail: {email}\n" +
                $"Programming score: {programmingScore}\n" +
                $"Math score: {mathScore}\n" +
                $"Physics score: {physicsScore}");
            Console.ReadKey();

            Console.WriteLine(
                $"Total score: {totalScore}\n" +
                $"Median score: {medianScore}");
            Console.ReadKey();

        }
    }
}
