using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teretana_Radnik.MVVM.Stores;
using Teretana_Radnik.MVVM.ViewModels;

namespace Teretana_Radnik.MVVM.Commands
{
    public class MakeUplateCommand : ICommand
    {
        private readonly NavigationStore _navigationStore;

        public MakeUplateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new SkenirajKarticuViewModel();
        }
    }
}
