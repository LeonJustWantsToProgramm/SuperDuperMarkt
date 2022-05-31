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
using System.Net.Http;

namespace SuperDuperMarkt
{
    /// <summary>
    /// Interaktionslogik für Anmeldefenster.xaml
    /// </summary>
    public partial class Anmeldefenster : Window
    {
        private static readonly HttpClient client = new HttpClient();
        string Kunden_Passwort;
        public Anmeldefenster()
        {
            InitializeComponent();
        }

        private async void AnmeldeBtn_Click(object sender, RoutedEventArgs e)
        {
            string Email = AnmeldeEMailTBox.Text;
            await getKundePasswort(Email);

            if (AnmeldeEMailTBox.Text.Equals(Email) && AnmeldePasswortTBox.Password.Equals(Kunden_Passwort))
            {
                ProduktauswahlFenster produktauswahlFenster = new ProduktauswahlFenster(AnmeldeEMailTBox.Text);
                produktauswahlFenster.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Anmeldung fehlgeschlagen! Vergewissern Sie sich, dass Sie die richtigen Daten eingeben");
            }
        }

        public async Task getKundePasswort(string Email)
        {
            var values = new Dictionary<string, string>
            {
                { "Email", Email }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/getKunde.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            string str1 = responseString.Replace(",", "");
            string str2 = str1.Replace(":", "");
            string str3 = str2.Replace("\"", ":");
            string[] a = str3.Split(':');

            Kunden_Passwort = a[35];
        }
    }
}
