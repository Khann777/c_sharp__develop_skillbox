using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Practice7
{
    internal class Repository
    {
        private Worker[] workers;
        private string path;
        uint index;
        string[] titles;

        /// <summary>
        /// Constructor for struct "Repository"
        /// </summary>
        /// <param name="Path">String of file name to create</param>
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[5];
            this.workers = new Worker[2];
        }

        /// <summary>
        /// Resises length of repository array
        /// </summary>
        /// <param name="Flag">If true adds 1 to array length</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length + 1);
            }
        }

        /// <summary>
        /// Creates new repository file
        /// </summary>
        public void CreateFile()
        {
            StreamWriter sw = new StreamWriter($@"{this.path}.txt");
        }

        /// <summary>
        /// Prints all worker records to console
        /// </summary>
        /// <returns>Returns array of type worker</returns>
        public Worker[] GetAllWorkers()
        {
            Worker[] workers = new Worker[this.workers.Length];
            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                Console.WriteLine("---------------Employees---------------");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];

                        Console.WriteLine($"Employee {workers[i].FullName}\n" +
                            $"ID: {workers[i].Id}\n" +
                            $"Record date: {workers[i].RecordDate}\n" +
                            $"Full Name: {workers[i].FullName}\n" +
                            $"Age: {workers[i].Age}\n" +
                            $"Birth date: {workers[i].BirthDate}\n" +
                            $"Height: {workers[i].Height}\n" +
                            $"Birth place: {workers[i].BirthPlace}\n\n");
                    }
                }
            }
            return workers;
        }

        /// <summary>
        /// Searches worker id in repository file and prints
        /// </summary>
        /// <param name="id">number to search by</param>
        /// <returns>Worker with searched id</returns>
        public Worker GetWorkerById(int id)
        {
            Worker[] workers = new Worker[this.workers.Length];

            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];

                        if (workers[i].Id == id)
                        {
                            index = i;
                            Console.WriteLine($"Employee {workers[i].FullName}\n" +
                            $"ID: {workers[i].Id}\n" +
                            $"Record date: {workers[i].RecordDate}\n" +
                            $"Full Name: {workers[i].FullName}\n" +
                            $"Age: {workers[i].Age}\n" +
                            $"Birth date: {workers[i].BirthDate}\n" +
                            $"Height: {workers[i].Height}\n" +
                            $"Birth place: {workers[i].BirthPlace}\n\n");
                        }
                    }
                }
            }
            return workers[index];
        }

        /// <summary>
        /// Deletes worker record by id
        /// </summary>
        /// <param name="id">Id for searching record in file</param>
        public void DeleteWorker(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                int Countup = 0;
                while (!sr.EndOfStream)
                {
                    if (Countup != id)
                    {
                        using (StringWriter sw = new StringWriter(sb))
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                    Countup++;
                }
            }
            using (StreamWriter sw = new StreamWriter($@"{this.path}.txt"))
            {
                sw.Write(sb.ToString());
            }

        }

        /// <summary>
        /// Adds new record to the repository
        /// </summary>
        /// <param name="worker">Adds class worker to the repository</param>
        public void AddWorker(Worker worker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = worker;
            worker.Id = this.index;
            worker.RecordDate = DateTime.Now;
            Console.Write("Enter worker full name: ");
            worker.FullName = Console.ReadLine();
            Console.Write("Enter worker age: ");
            worker.Age = uint.Parse(Console.ReadLine());
            Console.Write("Enter worker birth date(dd.MM.yyyy): ");
            worker.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter worker height: ");
            worker.Height = uint.Parse(Console.ReadLine());
            Console.Write("Enter worker birth place: ");
            worker.BirthPlace = Console.ReadLine();

            string record = $"{worker.Id}#{worker.RecordDate}#{worker.FullName}#{worker.Age}#" +
                               $"{worker.BirthDate.ToString("dd.MM.yyyy")}" +
                               $"#{worker.Height}#{worker.BirthPlace}";

            StreamWriter sw = new StreamWriter($@"{this.path}.txt", true);
            using (sw)
            {
                sw.WriteLine(record);
            }

            this.index++;
        }

        /// <summary>
        /// Gets records from repository between two dates
        /// </summary>
        /// <param name="dateFrom">Start date to search for records</param>
        /// <param name="dateTo">End date for searching records</param>
        /// <returns>Array of workers found between dates</returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = new Worker[this.workers.Length];
            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];

                        if (dateFrom < workers[i].RecordDate && workers[i].RecordDate <= dateTo)
                        {
                            Console.WriteLine($"Employee {workers[i].FullName}\n" +
                            $"ID: {workers[i].Id}\n" +
                            $"Record date: {workers[i].RecordDate}\n" +
                            $"Full Name: {workers[i].FullName}\n" +
                            $"Age: {workers[i].Age}\n" +
                            $"Birth date: {workers[i].BirthDate}\n" +
                            $"Height: {workers[i].Height}\n" +
                            $"Birth place: {workers[i].BirthPlace}\n\n");
                        }
                    }
                }
                return workers;
            }
        }

        /// <summary>
        /// Splits worker records for fields
        /// </summary>
        public void SplitRecord()
        {
            Worker[] workers = new Worker[this.workers.Length];

            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];
                    }
                }
            }
        }
    }
}