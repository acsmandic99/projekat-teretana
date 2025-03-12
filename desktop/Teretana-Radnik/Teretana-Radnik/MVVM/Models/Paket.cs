using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Teretana_Radnik.MVVM.Models
{
    public class Paket
    {
		private string naziv;
		private int cena;
		private string opis;
		private int id;

        public Paket(string naziv, int cena, string opis, int id)
        {
            this.naziv = naziv;
            this.cena = cena;
            this.opis = opis;
            this.id = id;
        }

        public Paket(string naziv, int cena, string opis)
        {
            this.naziv = naziv;
            this.cena = cena;
            this.opis = opis;
        }

        public int Id
		{
			get { return id; }
			set { id = value; }
		}


		public string Opis
		{
			get { return opis; }
			set { opis = value; }
		}


		public int Cena
		{
			get { return cena; }
			set { cena = value; }
		}


		public string Naziv
		{
			get { return naziv; }
			set { naziv = value; }
		}

	}
}
