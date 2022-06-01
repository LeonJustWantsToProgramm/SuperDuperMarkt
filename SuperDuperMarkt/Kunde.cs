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
        public string KundenID { get; set; }

        public List<Kunde> kundenList = new List<Kunde>();

        public List<Produkt> warenkorb;

        // Setzt alle Variablen den übergebenen Werten gleich, erstellt einen Warenkorb für den Kunden und fügt den Kunden zur Datenbank hinzu
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
            warenkorb = new List<Produkt>();
            kundenList.Add(this);
            addKunde(nachname, vorname, strasse, hausNr, Convert.ToString(plz), ort, e_Mail, passwort);
        }

        public Kunde() { }


        //  fügt ein Produkt zum Warenkorb hinzu
        public void AddToWarenkorb(Produkt produkt)
        {
            warenkorb.Add(produkt);
        }

        public List<Produkt> GetWarenkorb()
        {
            return this.warenkorb;
        }

        // Fügt den neuen Kunden der Datenbank hinzu
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
                { "Email", EMail },
                { "Passwort", Passwort }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://mysmartnutrition.de/v1/addKunde.php", content);
        }

        // Ruft die Kundeninformationen mithilfe der E-Mail-Adresse aus der Datenbank ab
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

            this.KundenID = a[4];
            this.nachname = a[7];
            this.vorname = a[11];
            this.strasse = a[15];
            this.hausNr = a[19];
            this.plz = Convert.ToInt32(a[23]);
            this.ort = a[27];
            this.e_Mail = a[31];
            this.passwort = a[35];

        }
    }
}
