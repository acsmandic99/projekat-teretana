using System.Windows;
using System.Windows.Input;
using Teretana_Radnik.MVVM.Stores;
using Teretana_Radnik.MVVM.ViewModels;

namespace Teretana_Radnik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationStore _navigationStore = new NavigationStore();
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new UnosNovogKorisnikaViewModel();
            
            MainWindow mainView = new MainWindow(); 
            mainView.DataContext = new MainViewModel(_navigationStore);
            mainView.Show();
            base.OnStartup(e);

        }

    }


}
