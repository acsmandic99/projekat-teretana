using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teretana_Radnik.MVVM.Models;

namespace Teretana_Radnik.MVVM.ViewModels
{
     public class SkenirajKarticuViewModel : ViewModelBase
    {
		private string id;
		private Clan trenutniClan;
		public string ID
		{
			get { return id; }
			set { id = value; OnPropertyChanged(nameof(ID)); }
		}

		public Clan TrenutniClan
		{
			get => trenutniClan;
			set
			{
				trenutniClan = value;
				OnPropertyChanged(nameof(TrenutniClan));
			}
        }

		public string TrenutniClanIme
		{
			get => trenutniClan.Ime;
		}
        public string TrenutniClanPrezime
        {
            get => trenutniClan.Prezime;
        }

		public string TrenutniClanDatUcla
		{
			get => trenutniClan.DatUclanjenja.ToString();
		}

		public IEnumerable<Clanstvo> TrenutniClanClanstva
		{
			get => trenutniClan.Clanstva;
		}

        public IEnumerable<Trening> TrenutniClanTreninzi
        {
            get => trenutniClan.Treninzi;
        }
    }

}
