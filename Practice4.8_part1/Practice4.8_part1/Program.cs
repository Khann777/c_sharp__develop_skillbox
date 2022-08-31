using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4._8_part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter row amount: ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Enter column amount: ");
            int column = int.Parse(Console.ReadLine());

            Random random = new Random();
            
            int[,] matrixA = new int[row, column];
            int[,] matrixB = new int[row, column];
            int[,] matrixC = new int[row, column];

            int sum = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrixA[i, j] = random.Next(20);
                    sum += matrixA[i, j];
                    Console.Write($"{matrixA[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Sum of all elementsof matrix A: {sum} \n");

            sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrixB[i, j] = random.Next(20);
                    sum += matrixB[i, j];
                    Console.Write($"{matrixB[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Sum of all elements of matrix B: {sum}\n");

            sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int matrixAddNumber = matrixA[i,j] + matrixB[i,j];
                    matrixC[i, j] = matrixAddNumber;
                    sum += matrixAddNumber;
                    Console.Write($"{matrixC[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Sum of all elements of matrix C: {sum}\n");

            Console.ReadKey();
        }
    }
}
