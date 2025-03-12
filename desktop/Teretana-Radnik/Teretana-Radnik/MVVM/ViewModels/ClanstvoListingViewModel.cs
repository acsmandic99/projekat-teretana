using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teretana_Radnik.MVVM.Models;

namespace Teretana_Radnik.MVVM.ViewModels
{
    public class ClanstvoListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ClanstvoViewModel> _list;

        public IEnumerable<ClanstvoViewModel> List { get=>_list; }

        public ClanstvoListingViewModel()
        {
            _list = new ObservableCollection<ClanstvoViewModel>();
            _list.Add(new ClanstvoViewModel(new Clanstvo(new Clan("Milos", "Mandic"), 1, new Paket("Full body", 1000, "opis", 1), new Uplata(DateTime.Now, NacinUplate.KARTICA))));
            _list.Add(new ClanstvoViewModel(new Clanstvo(new Clan("Milos", "Mandic"), 1, new Paket("Jutro", 1000, "opis", 1), new Uplata(DateTime.Now.AddDays(2), NacinUplate.KARTICA))));
        }
    }
}
