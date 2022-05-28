using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace SuperDuperMarkt
{
    class Bestellung
    {
        private static readonly HttpClient client = new HttpClient();
        public double gesamtPreis { get; set; }
        public string bestellDatum { get; set; }
        
        private Kunde kunde;
        private List<Produkt> produktList;


        public Bestellung(double gesamtPreis, string bestellDatum, Kunde kunde, List<Produkt> produktList)
        {
            this.gesamtPreis = gesamtPreis;
            this.bestellDatum = bestellDatum;
            this.kunde = kunde;
            this.produktList = produktList;
            string produktIDs = "";
            foreach(Produkt p in produktList)
            {
                produktIDs += p.produktID;
            }
            addBestellung(Convert.ToString(gesamtPreis), kunde.KundenID, produktIDs);
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
    }
}
