using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace SuperDuperMarkt
{
    public class Bestellung
    {
        private static readonly HttpClient client = new HttpClient();
        public double gesamtPreis { get; set; }
        public string bestellDatum { get; set; }
        public string email { get; set; }

        Kunde kunde;

        private List<Produkt> produktList;


        public Bestellung(double gesamtPreis, String Email, List<Produkt> produktList)
        {
            this.gesamtPreis = gesamtPreis;
            this.email = email;
            this.produktList = produktList;
            string produktIDs = "";
            foreach(Produkt p in produktList)
            {
                produktIDs += p.produktID;
            }
            addBestellung(Convert.ToString(gesamtPreis), Email, produktIDs);
        }


        // Fügt die Bestellung mit dem Gesamtpreis, der KundenID und ProduktIDs der Datenbank hinzu
        public async void addBestellung(string Gesamtpreis, string Customer_Mail, string Produkte_ID)
        {
            var values = new Dictionary<string, string>
            {
                { "Gesamtpreis", Gesamtpreis },
                { "Customer_ID", Customer_Mail },
                { "Produkte_ID", Produkte_ID }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addBestellung.php", content);
        }
    }
}
