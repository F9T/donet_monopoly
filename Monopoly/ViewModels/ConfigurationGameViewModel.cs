using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Monopoly.Models;
using MonopolyCommon;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;

namespace Monopoly.ViewModels
{
    public class ConfigurationGameViewModel : IViewModel
    {

        public ConfigurationGameViewModel()
        {
            Model = new ConfigurationGame();
            SelectedPlayer = null;
            Initialize();
        }

        private void Initialize()
        {
            AddPlayerCommand = new RelayCommand(_param => AddPlayer(), _param => CanAddPlayer());
            DeletePlayerCommand = new RelayCommand(_param => DeletePlayer(), _param => SelectedPlayer != null);
            BrowseGameCommand = new RelayCommand(_param => BrowseGme(), _param => true);
            CancelCommand = new RelayCommand(_param => DeletePlayer(), _param => true);
            PlayCommand = new RelayCommand(_param => DeletePlayer(), _param => true);
        }

        private void AddPlayer()
        {
            ((ConfigurationGame)Model).AddPlayer();
            SelectedPlayer = ((ConfigurationGame) Model).SelectedPlayer;
        }

        private void DeletePlayer()
        {
            ((ConfigurationGame)Model).DeleteSelectedPlayer();
        }

        private void BrowseGme()
        {
            
        }

        private bool CanAddPlayer()
        {
            return ((ConfigurationGame) Model).CanAddPlayer();
        }

        public IModel Model { get; set; }

        public ICommand AddPlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand BrowseGameCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand PlayCommand { get; set; }

        public Player SelectedPlayer
        {
            get => ((ConfigurationGame) Model).SelectedPlayer;
            set
            {
                ((ConfigurationGame)Model).SelectedPlayer = value;
                OnPropertyChanged(nameof(SelectedPlayer));
            }
        }

        public ObservableCollection<Player> Players
        {
            get => ((ConfigurationGame)Model).Players;
            set
            {
                ((ConfigurationGame)Model).Players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        public void Dispose()
        {
            Model?.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
