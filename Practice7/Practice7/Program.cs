using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter repository path: ");
            string path = Console.ReadLine();

            Repository repository = new Repository(path);

            Console.WriteLine("Choose what you want to do:\n" +
                "1. Create new file\n" +
                "2. Add new worker\n" +
                "3. Delete worker\n" +
                "4. Get all workers records\n" +
                "5. Get one worker record\n" +
                "6. Get worker records between two dates\n" +
                "7. Exit");

            Console.Write("Enter operation number: ");
            int operationNumber = int.Parse(Console.ReadLine());

            while (operationNumber != 7)
            {
                switch (operationNumber)
                {
                    case 1:
                        repository.CreateFile();
                        Console.WriteLine("File created");
                        break;
                    case 2:
                        Worker worker = new Worker();
                        repository.AddWorker(worker);
                        Console.WriteLine("Worker added");
                        break;
                    case 3:
                        Console.Write("Enter worker id to delete: ");
                        repository.DeleteWorker(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Worker deleted");
                        break;
                    case 4:
                        repository.GetAllWorkers();
                        break;
                    case 5:
                        Console.Write("Enter worker id to search: ");
                        repository.GetWorkerById(int.Parse(Console.ReadLine()));
                        break;
                    case 6:
                        Console.Write("Enter date to get record from: ");
                        DateTime dateFrom = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter date to get record from: ");
                        DateTime dateTo = DateTime.Parse(Console.ReadLine());
                        repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                        break;
                    default:
                        if (operationNumber > 7)
                        {
                            Console.WriteLine("You have entered wrong operation number, try again");
                        }
                        break;
                }

                Console.Write("Enter operation number: ");
                operationNumber = int.Parse(Console.ReadLine());

            }

        }
    }
}
