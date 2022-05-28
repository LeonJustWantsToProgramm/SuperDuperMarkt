using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für KundenErstellen.xaml
    /// </summary>
    public partial class KundenErstellen : Window
    {
        Kunde kunde;

        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        public KundenErstellen()
        {
            InitializeComponent();
        }


        private void BestätigenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kunde = new Kunde(VornameTBox.Text, NachnameTBox.Text, Convert.ToInt32(PLZTBox.Text), OrtTBox.Text, StraßeTBox.Text, HausNrTBox.Text, EMailTBox.Text, PasswortTBox.Text);
                MessageBox.Show("Neuer Kunde wurde erstellt!");
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show("Bitte geben Sie in jedes Textfeld einen logischen Wert ein.\n" + ex.Message);
            }
            
        }

        private void PLZTBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
