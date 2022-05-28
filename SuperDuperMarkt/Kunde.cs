using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SuperDuperMarkt
{
    class Kunde
    {
        private static readonly HttpClient client = new HttpClient();
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int plz { get; set; }
        public string ort { get; set; }
        public string strasse { get; set; }
        public string hausNr { get; set; }

        
        public Kunde(string vorname, string nachname, int plz, string ort, string strasse, string hausNr)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.plz = plz;
            this.ort = ort;
            this.strasse = strasse;
            this.hausNr = hausNr;
            addKunde(nachname, vorname, strasse, hausNr, Convert.ToString(plz), ort);
        }

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
    }
}
