using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDuperMarkt
{
    class Kunde
    {
        private string vorname;
        private string nachname;
        private string geburtstag;
        private string plz;
        private string ort;
        private string strasse;
        private string hausNr;

        public Kunde(string vorname, string nachname, string geburtstag, string plz, string ort, string strasse, string hausNr)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtstag = geburtstag;
            this.plz = plz;
            this.ort = ort;
            this.strasse = strasse;
            this.hausNr = hausNr;
        }


    }
}
