using System.Windows;
using System.Windows.Input;
using MonopolyCommon;
using MonopolyCommon.Interfaces;

namespace Monopoly.ViewModels
{
    public class MainViewModel : AbstractFileManager, IViewModel
    {
        public MainViewModel()
        {
            PlatterViewModel = new PlatterViewModel();

            NewGameCommand = new RelayCommand(_param => New(), _param => true);
        }

        protected override void New()
        {
            var configPlayers = new ConfigurationGameWindow
            {
                Owner = Application.Current.MainWindow
            };
            configPlayers.ShowDialog();
            PlatterViewModel.Deserialize(@"D:\HE-ARC\DotNet\Projets\monopoly\dotnet_monopoly\Monopoly\PlatterExample\example.xml");
        }

        protected override bool Close()
        {
            return true;
        }

        protected override void Load() { }

        protected override void Save() { }

        protected override void SaveAs(){ }

        public IModel Model { get; set; }

        public PlatterViewModel PlatterViewModel { get; set; }

        public ICommand NewGameCommand { get; set; }

        public void Dispose()
        {
        }
    }
}
