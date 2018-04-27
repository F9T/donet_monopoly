using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MonopolyCommon;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;

namespace Monopoly.ViewModels
{
    public class MainViewModel : AbstractFileManager, IViewModel
    {
        private PlatterViewModel platterViewModel;

        public MainViewModel()
        {
            PlatterViewModel = new PlatterViewModel();
            //PlatterViewModel.Deserialize(@"D:\HE-ARC\DotNet\Projets\monopoly\classic.xml");

            NewGameCommand = new RelayCommand(_param => New(), _param => true);
        }

        protected override void New()
        {
            var configPlayers = new ConfigurationGameWindow
            {
                Owner = Application.Current.MainWindow
            };
            configPlayers.ShowDialog();
            if (!configPlayers.ConfigurationGameViewModel.IsCancelled)
            {
                var pathGame = configPlayers.ConfigurationGameViewModel.PathGame;
                PlatterViewModel.Deserialize(pathGame);
                PlatterViewModel.Players = new ObservableCollection<Player>(configPlayers.ConfigurationGameViewModel.Players);
            }
        }

        protected override bool Close()
        {
            return true;
        }

        protected override void Load() { }

        protected override void Save() { }

        protected override void SaveAs(){ }

        public IModel Model { get; set; }

        public PlatterViewModel PlatterViewModel
        {
            get => platterViewModel;
            set
            {
                platterViewModel = value;
                OnPropertyChanged(nameof(PlatterViewModel));
            }
        }

        public ICommand NewGameCommand { get; set; }

        public void Dispose()
        {
        }
    }
}
