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
    /// Interaktionslogik für ProduktauswahlFenster.xaml
    /// </summary>
    public partial class ProduktauswahlFenster : Window
    {
        public ProduktauswahlFenster(string contentFromLastWindow)
        {
            InitializeComponent();
            tbxKunde.Text = contentFromLastWindow;
        }
        Produkt produkt = new Produkt();
        Kunde kunde = new Kunde();
        string Artikelnummer;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Artikelnummer = tbxArtikelnummer.Text;
                await produkt.getProduktInformations(Artikelnummer);

                P_Name.Text = produkt.produktName;
                P_Preis.Text = Convert.ToString(produkt.preis);
                P_Beschreibung.Text = produkt.produktBeschr;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dieses Produkt existiert nicht");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
