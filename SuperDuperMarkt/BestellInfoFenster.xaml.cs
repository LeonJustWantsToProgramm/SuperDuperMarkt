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
using System.Windows.Shapes;

namespace SuperDuperMarkt
{
    /// <summary>
    /// Interaktionslogik für BestellInfoFenster.xaml
    /// </summary>
    public partial class BestellInfoFenster : Window
    {
        private Kunde kunde = new Kunde();

        public BestellInfoFenster(string contentFromLastWindow)
        {
            InitializeComponent();
            kunde = contentFromLastWindow;
            BestellInfoContent.ItemsSource = kunde.warenkorb;
        }

        // Verwirft die Bestellung und löscht damit den Warenkorb und schließt das Fenster
        private void VerwerfenBtn_Click(object sender, RoutedEventArgs e)
        {
            kunde.warenkorb.Clear();
            this.Close();
        }


        private void BestellungAufgebenBtn_Click(object sender, RoutedEventArgs e)
        {
            Bestellung bestellung = new Bestellung(Convert.ToDouble(GesamtPreisLabel.Content), tbxKunde.Text,  GetWarenkorbOfCustomer());
            MessageBox.Show("Ihre Bestellung wurde aufgegeben");
        }
    }
}
