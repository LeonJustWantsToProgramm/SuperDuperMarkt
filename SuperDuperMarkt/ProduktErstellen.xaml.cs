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
    /// Interaktionslogik für ProduktErstellen.xaml
    /// </summary>
    public partial class ProduktErstellen : Window
    {
        public ProduktErstellen()
        {
            InitializeComponent();
        }
        double preis;
        Produkt produkt;
        private void BestätigenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = Convert.ToString(PreisBox.Text.Replace(".", ","));
                preis = Convert.ToDouble(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitte geben Sie für den Preis einen logischen Wert ein.\n" + ex.Message);
            }

            try
            {
                produkt = new Produkt(NameBox.Text, preis, BeschreibungBox.Text);
                MessageBox.Show("Neues Produkt wurde erstellt!" + preis);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitte geben Sie in jedes Textfeld einen logischen Wert ein.\n" + ex.Message);
            }
        }
    }
}
