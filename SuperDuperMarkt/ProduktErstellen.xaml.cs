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

        private void BestätigenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string content = Convert.ToString(PreisBox.Text.Replace(",", "."));
                double a = Convert.ToDouble(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bitte geben Sie für den Preis einen logischen Wert ein.\n" + ex.Message);
            }
        }
    }
}
