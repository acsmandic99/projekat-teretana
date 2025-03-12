using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teretana_Radnik.MVVM.Models;

namespace Teretana_Radnik.MVVM.ViewModels
{
    public class ClanstvoViewModel : ViewModelBase
    {
        private readonly Clanstvo _clanstvo;
        public string DatumUplate { get=> _clanstvo.Uplata.DatumUplate.Date.ToString("d");  }
        public string Naziv { get => _clanstvo.Paket.Naziv; }

        public ClanstvoViewModel(Clanstvo clanstvo)
        {
            _clanstvo = clanstvo;
        }
    }
}
