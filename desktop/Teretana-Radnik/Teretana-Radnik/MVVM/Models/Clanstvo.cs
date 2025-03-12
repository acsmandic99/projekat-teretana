using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teretana_Radnik.MVVM.Models
{
    public class Clanstvo
    {
        private Clan clan;
        private int id;
        private Paket paket;
        private Uplata uplata;
        private DateTime krajPaketa;

        public int Id { get => id; set => id = value; }
        public Clan Clan { get => clan; set => clan = value; }
        public Paket Paket { get => paket; set => paket = value; }

        public Uplata Uplata { get=> uplata; set => uplata = value; }
        
        public DateTime KrajPaketa { get => krajPaketa; set => krajPaketa = value; }

        public Clanstvo(Clan clan, int id, Paket paket, Uplata uplata)
        {
            this.clan = clan;
            this.id = id;
            this.uplata = uplata;
            this.paket = paket;
            this.krajPaketa = uplata.DatumUplate.AddMonths(1);
            this.uplata = uplata;
        }
    }
}
