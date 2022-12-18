using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Path = "ClientData.txt";
        sbyte switcher = -1;
        Consultant client;
        public ObservableCollection<Consultant> clients;

        public MainWindow()
        {
            clients = new ObservableCollection<Consultant>();
            client = new Consultant("dasdas", "deqweqw", "brtbrt", 211123, 211, 5423523);
            clients.Add(client);
            InitializeComponent();
            ClientListWriteClients();
            ClientList.ItemsSource = clients;
        }



        private void ClientList_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Takes clients data from file and adds to main window
        /// </summary>
        private void ClientListWriteClients()
        {
            string line;
            Consultant client;
            using (StreamReader sr = new StreamReader(Path))
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < line.Count(); i++)
                    {
                        string[] record = line.Split(' ');
                        client = new Consultant(record[0],
                                                record[1],
                                                record[2],
                                                uint.Parse(record[3]),
                                                uint.Parse(record[4]),
                                                uint.Parse(record[5]));
                        clients.Add(client);
                    }
                    
                }
            }
        }


        private void Accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Accounts.SelectedIndex == 0)
            {
                switcher = 0;
            }
            if (Accounts.SelectedIndex == 1)
            {
                switcher = 1;
                AddClientButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Client change info window constructor
        /// </summary>
        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Consultant selectedClient = ClientList.SelectedItem as Consultant;
            ChangeInfoWindow changeInfoWindow = new ChangeInfoWindow();

            if (switcher == 0) // For Consultant
            {
                changeInfoWindow.Show();
                changeInfoWindow.FirstNameChangeBox.Text = selectedClient.FirstName;
                changeInfoWindow.FirstNameChangeBox.IsReadOnly = true;

                changeInfoWindow.LastNameChangeBox.Text = selectedClient.LastName;
                changeInfoWindow.LastNameChangeBox.IsReadOnly = true;

                changeInfoWindow.FathersNameChangeBox.Text = selectedClient.FathersName;
                changeInfoWindow.FathersNameChangeBox.IsReadOnly = true;

                changeInfoWindow.PhoneNumberChangeBox.Text = selectedClient.PhoneNumber.ToString();
                changeInfoWindow.ChangeButton.Content = "Change phone number";

                if (changeInfoWindow.PassportNumberChangeBox.Text != null)
                {
                    changeInfoWindow.PassportNumberChangeBox.Text = "***************";
                    changeInfoWindow.PassportNumberChangeBox.IsReadOnly = true;
                }
                if (changeInfoWindow.PassportSeriesChangeBox.Text != null)
                {
                    changeInfoWindow.PassportSeriesChangeBox.Text = "***************";
                    changeInfoWindow.PassportSeriesChangeBox.IsReadOnly = true;
                }
            }
            if (switcher == 1) // for Manager
            {
                changeInfoWindow.Show();
                changeInfoWindow.FirstNameChangeBox.Text = selectedClient.FirstName;
                changeInfoWindow.LastNameChangeBox.Text = selectedClient.LastName;
                changeInfoWindow.FathersNameChangeBox.Text = selectedClient.FathersName;
                changeInfoWindow.PhoneNumberChangeBox.Text = selectedClient.PhoneNumber.ToString();
                changeInfoWindow.PassportNumberChangeBox.Text = selectedClient.PassportNumber.ToString();
                changeInfoWindow.PassportSeriesChangeBox.Text = selectedClient.PassportSeries.ToString();
            }
            if (switcher == -1)
            {
                MessageBox.Show("Choose your account");
            }
        }

        /// <summary>
        /// On Button Click logics
        /// </summary>
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewClient addWindow = new AddNewClient();
            addWindow.Show();
        }

    }
}
