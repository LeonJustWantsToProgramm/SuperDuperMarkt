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




        private void ProduktSuchenBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KundenErstBtn_Click(object sender, RoutedEventArgs e)
        {
            // CreateDatabaseConnection();
            KundenErstellen kundenErstellenObj = new KundenErstellen();
            // this.Visibility = Visibility.Hidden;     // hides the current window
            kundenErstellenObj.Show();
        }

        private void BestellungAufgBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
