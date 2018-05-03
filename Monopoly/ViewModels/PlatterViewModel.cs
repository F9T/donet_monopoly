using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MonopolyCommon;
using MonopolyCommon.Cases;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;

namespace Monopoly.ViewModels
{
    public class PlatterViewModel : IViewModel
    {
        private Die dieOne;
        private Die dieSecond;
        private string infoBulle;

        public PlatterViewModel()
        {
            Model = new Platter();
            DieOne = new Die(1, 6);
            DieSecond = new Die(1, 6);
            RollDiceCommand = new RelayCommand(_param => RollDice(), _param => IsStarted);
        }

        public void RollDice()
        {
            DieOne.Roll();
            DieSecond.Roll();

            int sum = DieOne.Roll() + DieSecond.Roll();

            if(sum == 12)
            {
                InfoBulle = "12! Relancez";
            }
            else
            {
                InfoBulle = "Avancez de " + sum + " cases";

            }
            
        }

        public IModel Model { get; set; }

        public string InfoBulle
        {
            get => infoBulle;
            set
            {
                infoBulle = value;
                OnPropertyChanged(nameof(InfoBulle));
            }
        }

        public bool IsStarted
        {
            get => ((Platter)Model).IsStarted;
            set
            {
                ((Platter)Model).IsStarted = value;
                OnPropertyChanged(nameof(IsStarted));
            }
        }

        public string PathFile
        {
            get => ((Platter)Model).PathFile;
            set
            {
                ((Platter)Model).PathFile = value;
                OnPropertyChanged(nameof(PathFile));
            }
        }

        public Die DieOne
        {
            get => dieOne;
            set
            {
                dieOne = value;
                OnPropertyChanged(nameof(DieOne));
            }
        }

        public Die DieSecond
        {
            get => dieSecond;
            set
            {
                dieSecond = value;
                OnPropertyChanged(nameof(DieSecond));
            }
        }

        public Player CurrentPlayer
        {
            get => ((Platter)Model).CurrentPlayer;
            set
            {
                ((Platter)Model).CurrentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public ObservableCollection<Player> Players
        {
            get => ((Platter) Model).Players;
            set
            {
                ((Platter) Model).Players = value;
                OnPropertyChanged(nameof(Players));
            }
        }

        public ObservableCollection<AbstractCase> Cases
        {
            get => ((Platter) Model).Cases;
            set
            {
                ((Platter) Model).Cases = value;
                OnPropertyChanged(nameof(Cases));
            }
        }

        private void Update()
        {
            Cases = ((Platter)Model).Cases;
            Players = ((Platter)Model).Players;
            PathFile = ((Platter)Model).PathFile;
            IsStarted = true;
            CurrentPlayer = Players[0];
        }

        public void AddPlayers(IEnumerable<Player> _playerList)
        {
            ((Platter) Model).Players = new ObservableCollection<Player>(_playerList);
            Players = ((Platter) Model).Players;
        }

        public void Serialize(string _path)
        {
            PlatterSerializer.Serialize((Platter) Model);
        }

        public void Deserialize(string _path)
        {
            ((Platter) Model).Serialize(_path);
            Update();
        }

        public ICommand RollDiceCommand { get; set; }

        public void Dispose()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
        
    }
}
