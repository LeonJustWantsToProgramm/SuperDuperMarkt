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
        private Produkt produkt = new Produkt();
        private Kunde kunde = new Kunde();
        private string Artikelnummer;


        public ProduktauswahlFenster(string contentFromLastWindow)
        {
            InitializeComponent();
            tbxKunde.Text = contentFromLastWindow;
        }

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

        /// <summary>
        /// Fügt das ausgewählte Produkt zum Warenkorb des entsprechenden Kunden hinzu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Kunde kunde in kunde.kundenList)
            {
                if (kunde.e_Mail.Equals(tbxKunde.Text))
                {
                    kunde.warenkorb.Add(new Produkt(P_Name.Text, Convert.ToDouble(P_Preis.Text), P_Beschreibung.Text));
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BestellInfoFenster bstIF = new BestellInfoFenster(tbxKunde.Text);
            bstIF.Show();
            this.Close();
        }
    }
}
