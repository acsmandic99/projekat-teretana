using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teretana_Radnik.MVVM.Commands;
using Teretana_Radnik.MVVM.Stores;

namespace Teretana_Radnik.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ICommand SkenirajKarticuCommand { get; }
        public ICommand UnosNovogKorisnikaCommand { get; }
        public ICommand UplateCommand { get; }

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;


            SkenirajKarticuCommand = new MakeViewCommand(_navigationStore,new SkenirajKarticuViewModel());
            UnosNovogKorisnikaCommand = new MakeViewCommand(_navigationStore,new UnosNovogKorisnikaViewModel());
            UplateCommand = new MakeViewCommand(_navigationStore,new UplateViewModel());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

    }
}
