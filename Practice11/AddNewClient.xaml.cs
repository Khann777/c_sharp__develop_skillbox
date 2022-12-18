using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practice11
{
    /// <summary>
    /// Логика взаимодействия для AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        public AddNewClient()
        {
            InitializeComponent();
        }


        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Consultant client = new Consultant(LastNameChangeBox.Text,
                                                   FirstNameChangeBox.Text,
                                                   FathersNameChangeBox.Text,
                                                   uint.Parse(PhoneNumberChangeBox.Text),
                                                   uint.Parse(PassportSeriesChangeBox.Text),
                                                   uint.Parse(PassportNumberChangeBox.Text));

            using (StreamWriter sw = new StreamWriter(mw.Path, true))
            {
                sw.WriteLine(client.ViewInformation());
                mw.clients.Add(client);
            }
            mw.ClientList.Items.Refresh();
            Close();
        }
    }
}
