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
using System.Net.Http;

//using System.Net.Http;   ergänzen!


namespace WpfApp1
{
    public partial class MethodenVorlagen
    {
        private static readonly HttpClient client = new HttpClient();

        public async void addKunde(string Nachname, string Vorname, string Strasse, string Hausnummer, string PLZ, string Ort)
        {
            var values = new Dictionary<string, string>
            {
                { "Nachname", Nachname },
                { "Vorname", Vorname },
                { "Strasse", Strasse },
                { "Hausnummer", Hausnummer },
                { "PLZ", PLZ },
                { "Ort", Ort }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addKunde.php", content);
        }

        public async void addProdukt(string Name, string Preis, string Beschreibung)
        {
            var values = new Dictionary<string, string>
            {
                { "Name", Name },
                { "Preis", Preis },
                { "Beschreibung", Beschreibung }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addProdukt.php", content);
        }

        public async void addBestellung(string Gesamtpreis, string Customer_ID, string Produkte_ID)
        {
            var values = new Dictionary<string, string>
            {
                { "Gesamtpreis", Gesamtpreis },
                { "Customer_ID", Customer_ID },
                { "Produkte_ID", Produkte_ID }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addBestellung.php", content);
        }

        public async void getLastProduktID()
        {
            var values = new Dictionary<string, string>
            {
                { "N/A", "N/A" },
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/getLastProduktID.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            string[] a = responseString.Split(":");
            int result = Convert.ToInt32(a[2].Replace("}", ""));
        }

        public async void getProduktInformations(string P_ID)
        {
            var values = new Dictionary<string, string>
            {
                { "Produkt_ID", P_ID }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/getProdukt.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            string str1 = responseString.Replace(",", "");
            string str2 = str1.Replace(":", "");
            string str3 = str2.Replace("\"", ":");
            string[] a = str3.Split(":");
            
            string Produkt_ID = a[4];
            string Produkt_Name = a[7];
            string Produkt_Preis = a[10];
            string Produkt_Beschreibung = a[13];
        }
    }
}
