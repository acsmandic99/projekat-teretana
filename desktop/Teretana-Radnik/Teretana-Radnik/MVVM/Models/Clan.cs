using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teretana_Radnik.MVVM.Models
{
    public class Clan
    {
        private string ime;
        private string prezime;
        private int id;

        public Clan(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }

        public Clan(string ime, string prezime, int id) : this(ime, prezime)
        {
            this.id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }


        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

    }
}
