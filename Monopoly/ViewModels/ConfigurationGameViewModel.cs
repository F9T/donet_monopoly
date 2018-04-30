using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
using Monopoly.Models;
using MonopolyCommon;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;
using Xceed.Wpf.Toolkit;

namespace Monopoly.ViewModels
{
    public class ConfigurationGameViewModel : IViewModel
    {
        public ConfigurationGameViewModel()
        {
            Model = new ConfigurationGame();
            AvailableColors = ((ConfigurationGame) Model).AvailableColors;
            SelectedPlayer = null;
            IsCancelled = false;
            Initialize();
        }

        private void Initialize()
        {
            AddPlayerCommand = new RelayCommand(_param => AddPlayer(), _param => CanAddPlayer());
            DeletePlayerCommand = new RelayCommand(_param => DeletePlayer(), _param => SelectedPlayer != null);
            BrowseGameCommand = new RelayCommand(_param => BrowseGme(), _param => true);
            CancelCommand = new RelayCommand(_param => CancelGame(), _param => true);
            PlayCommand = new RelayCommand(_param => StartGame(), _param => CanPlayGame());
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

        private bool CanPlayGame()
        {
            if (PathGame.Equals(""))
            {
                return false;
            }
            var fileInfo  = new FileInfo(PathGame);
            return Players.Count >= 2 && fileInfo.Exists;
        }


        private void StartGame()
        {
            var window = Utilities.GetOwnedWindow();
            // just for to be sure
            IsCancelled = false;
            window?.Close();
        }

        private void BrowseGme()
        {
            var fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "XML Files (*.xml)| *.xml"
            };
            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                PathGame = fileDialog.FileName;
            }
        }

        private void CancelGame()
        {
            var window = Utilities.GetOwnedWindow();
            IsCancelled = true;
            window?.Close();
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

        public string PathGame
        {
            get => ((ConfigurationGame) Model).PathGame;
            set
            {
                ((ConfigurationGame) Model).PathGame = value;
                OnPropertyChanged(nameof(PathGame));
            }
        }

        public bool IsCancelled { get; set; }

        public ObservableCollection<ColorItem> AvailableColors { get; set; }

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
