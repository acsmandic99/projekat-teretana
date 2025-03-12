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
    public class MakeViewCommand : ICommand
    {
        private readonly NavigationStore navigationStore;
        private ViewModelBase changeModel;

        public MakeViewCommand(NavigationStore navigationStore, ViewModelBase changeModel)
        {
            this.navigationStore = navigationStore;
            this.changeModel = changeModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = changeModel;
        }
    }
}
