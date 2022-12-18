using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practice11
{
    public class Consultant
    {
        
        #region Constructor
        /// <summary>
        /// ClientData class constructor
        /// </summary>
        /// <param name="LastName">Clients last name</param>
        /// <param name="FirstName">Client first name</param>
        /// <param name="FathersName">Clients fathers name or second name</param>
        /// <param name="PhoneNumber">Clients phone number</param>
        /// <param name="PassportSeries">Clients passport series</param>
        /// <param name="PassportNumber">Clients passport number</param>
        public Consultant(string LastName, string FirstName, string FathersName,
            uint PhoneNumber, uint PassportSeries, uint PassportNumber)
        {
            this.lastName = LastName;
            this.firstName = FirstName;
            this.fathersName = FathersName;
            this.phoneNumber = PhoneNumber;
            this.passportSeries = PassportSeries;
            this.passportNumber = PassportNumber;
        }

        public Consultant() { }
        #endregion
 
        #region Fields
        /// <summary>
        /// Clients last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// Clients first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// Clients fathers name or second name
        /// </summary>
        private string fathersName;

        /// <summary>
        /// Clients phone number
        /// </summary>
        private uint phoneNumber;

        /// <summary>
        /// Clients passport series
        /// </summary>
        private uint passportSeries;

        /// <summary>
        /// Clients passport number
        /// </summary>
        private uint passportNumber;
        #endregion

        #region Properties
        /// <summary>
        /// Clients last name
        /// </summary>
        public string LastName { get { return this.lastName; } protected set { this.lastName = value; } }

        /// <summary>
        /// Clients first name
        /// </summary>
        public string FirstName { get { return this.firstName; } protected set { this.firstName = value; } }

        /// <summary>
        /// Clients fathers name or second name
        /// </summary>
        public string FathersName { get { return this.fathersName; } protected set { this.fathersName = value; } }

        /// <summary>
        /// Clients phone number
        /// </summary>
        public uint PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }

        /// <summary>
        /// Clients passport series
        /// </summary>
        public uint PassportSeries { get { return this.passportSeries; }protected set { this.passportSeries = value; } }

        /// <summary>
        /// Clients passport number
        /// </summary>
        public uint PassportNumber { get { return this.passportNumber; } protected set { this.passportNumber = value; } }
        #endregion

        #region Methods
        /// <summary>
        /// Shows clients information
        /// </summary>
        public string ViewInformation()
        {
            return $"{FirstName} {LastName} {FathersName} " +
                $"{PassportSeries} {PassportNumber} " +
                $"{PhoneNumber}";
        }

        /// <summary>
        /// Changes clients phone number in data file
        /// </summary>
        /// <param name="neededName">Name of client to change phone</param>
        /// <param name="newNumber">New phone number to add to file</param>
        public void ChangePhoneNumber(string neededName, uint newNumber)
        {
            MainWindow mainWindow = new MainWindow();
            string line;
            using (StreamReader sr = new StreamReader(mainWindow.Path))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] record = line.Split(' ');
                    while (true)
                    {
                        if (neededName == FirstName)
                        {
                            LastName = record[0];
                            FirstName = record[1];
                            FathersName = record[2];
                            PhoneNumber = newNumber;
                            PassportSeries = uint.Parse(record[4]);
                            PassportNumber = uint.Parse(record[5]);

                            Consultant newClient = new Consultant(
                                LastName, FirstName, FathersName,
                                PhoneNumber, PassportSeries, PassportNumber);
                            DeleteClient(neededName);

                            using (StreamWriter sw = new StreamWriter(mainWindow.Path, true))
                            {
                                sw.WriteLine(newClient.ViewInformation());
                                mainWindow.clients.Add(newClient);
                            }
                            return;
                        }
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes client from data file
        /// </summary>
        /// <param name="neededName">Name of client to delete</param>
        public void DeleteClient(string neededName)
        {
            MainWindow mainWindow = new MainWindow();
            StringBuilder sb = new StringBuilder();
            string line;
            using (StreamReader sr = new StreamReader(mainWindow.Path))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        string[] record = line.Split(' ');
                        while (true)
                        {
                            if (neededName == FirstName)
                            {
                                LastName = record[0];
                                FirstName = record[1];
                                FathersName = record[2];
                                PhoneNumber = uint.Parse(record[3]);
                                PassportSeries = uint.Parse(record[4]);
                                PassportNumber = uint.Parse(record[5]);
                                return;
                            }
                            else
                            {
                                sr.ReadLine();

                                continue;
                            }
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(mainWindow.Path))
            {
                sw.Write(sb.ToString());
            }

        }

        #endregion
    }
}
