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
    /// Interaktionslogik für Anmeldefenster.xaml
    /// </summary>
    public partial class Anmeldefenster : Window
    {
        public Anmeldefenster()
        {
            InitializeComponent();
        }

        private void AnmeldeBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Hier Datenbankabfrage für E-Mail und Passwort machen und in einer Variable speichern


            if (AnmeldeEMailTBox.Text.Equals("Hier die Variable eintragen") && AnmeldePasswortTBox.Text.Equals("Hier die andere Variable eintragen"))
            {
                ProduktauswahlFenster produktauswahlFenster = new ProduktauswahlFenster();
                produktauswahlFenster.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Anmeldung fehlgeschlagen! Vergewissern Sie sich, dass Sie die richtigen Daten eingeben");
            }
        }
    }
}
