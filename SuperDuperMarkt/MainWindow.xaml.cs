using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SuperDuperMarkt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateDatabaseConnection()
        {
            // contains data that is needed for the database connection
            string connectionString = "server=db5007810181.hosting-data.io;uid=dbu1670119;pwd=rk3Zz3L1234;database=dbs6470968;";
            string query = "SELECT Name FROM Produkt";

            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {

                // Execute the query
                reader = commandDatabase.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Do something with every received database ROW
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // closes the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Shows any error message.
                MessageBox.Show(ex.Message);
            }
        }



        private void ProduktSuchenBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KundenErstBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateDatabaseConnection();
        }

        private void BestellungAufgBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
