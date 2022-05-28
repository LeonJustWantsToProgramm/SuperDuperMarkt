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
        public string e_Mail { get; set; }
        public string passwort { get; set; }

        public Kunde(string vorname, string nachname, int plz, string ort, string strasse, string hausNr, string e_Mail, string passwort)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.plz = plz;
            this.ort = ort;
            this.strasse = strasse;
            this.hausNr = hausNr;
            this.e_Mail = e_Mail;
            this.passwort = passwort;
            addKunde(nachname, vorname, strasse, hausNr, Convert.ToString(plz), ort, e_Mail, passwort);
        }

        public async void addKunde(string Nachname, string Vorname, string Strasse, string Hausnummer, string PLZ, string Ort, string EMail, string Passwort)
        {
            var values = new Dictionary<string, string>
            {
                { "Nachname", Nachname },
                { "Vorname", Vorname },
                { "Strasse", Strasse },
                { "Hausnummer", Hausnummer },
                { "PLZ", PLZ },
                { "Ort", Ort },
                { "EMail", EMail },
                { "Passwort", Passwort }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addKunde.php", content);
        }

        public async void getKundenInformations(string Email)
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

            string Kunden_ID = a[4];
            string Kunden_Nachname = a[7];
            string Kunden_Vorname = a[11];
            string Kunden_Strasse = a[15];
            string Kunden_Hausnummer = a[19];
            string Kunden_PLZ = a[23];
            string Kunden_Ort = a[27];
            string Kunden_Email = a[31];
            string Kunden_Passwort = a[35];

        }
    }
}
