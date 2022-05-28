using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace SuperDuperMarkt
{
    class Produkt
    {
        private static readonly HttpClient client = new HttpClient();

        public string produktID { get; set; }
        public string produktName { get; set; }
        public double preis { get; set; }
        public string produktBeschr { get; set; }

        public Produkt(string produktName, double preis, string produktBeschr)
        {
            this.produktName = produktName;
            this.preis = preis;
            this.produktBeschr = produktBeschr;
            addProdukt(produktName, Convert.ToString(preis), produktBeschr);
        }

        public Produkt()
        {

        }


        public async void addProdukt(string Name, string Preis, string Beschreibung)
        {
            string preisS = Convert.ToString(Preis.Replace(",", "."));
            var values = new Dictionary<string, string>
            {
                { "Name", Name },
                { "Preis", preisS },
                { "Beschreibung", Beschreibung }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addProdukt.php", content);
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
            string[] a = responseString.Split(':');
            int result = Convert.ToInt32(a[2].Replace("}", ""));
        }

        public async Task getProduktInformations(string P_ID)
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
            string[] a = str3.Split(':');

            this.produktID = a[4];
            this.produktName = a[7];
            this.preis = Convert.ToDouble(a[10].Replace(".", ","));
            this.produktBeschr = a[13];
        }
    }
}
