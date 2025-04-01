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
        }
    }
}
