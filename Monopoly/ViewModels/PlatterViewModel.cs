using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
//Speech
using System.Speech;
using System.Speech.Synthesis;
using System.Globalization;

using System.Runtime.CompilerServices;
using System.Windows.Input;
using MonopolyCommon;
using MonopolyCommon.Cases;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;

using System;

namespace Monopoly.ViewModels
{
    /// <summary>
    /// Main ViewModel for platter
    /// </summary>
    public class PlatterViewModel : IViewModel
    {
        // The game possess 2 dices to roll
        private Die dieOne;
        private Die dieSecond;

        // Info shown on screen when player roll the dice
        private string infoBulle;

        // Turn variables
        private int turnCount;
        private int doubleDiceCount;
        private bool doPlayAgain;

        public SpeechSynthesizer reader = new SpeechSynthesizer();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlatterViewModel()
        {
            // Init Platter model
            Model = new Platter();

            // Init dices
            DieOne = new Die(1, 6);
            DieSecond = new Die(1, 6);
            RollDiceCommand = new RelayCommand(_param => RollDice(), _param => IsStarted);

            // Init game vars
            turnCount = 0;
            doubleDiceCount = 0;
            doPlayAgain = false;

            //Set player cases
            foreach (Player player in Players)
            {
                player.CurrentCase = Cases[39];
            }
        }

        /// <summary>
        /// Voice reader
        /// </summary>
        /// <param name="toRead"></param>
        public void Reader(String toRead)
        {
            //Speech
            reader.Dispose();
            reader = new SpeechSynthesizer();
            //Change default voice
            reader.SelectVoiceByHints(VoiceGender.Male);
            reader.SpeakAsync(toRead);

        }

        /// <summary>
        /// Action roll dice for player
        /// </summary>
        public void RollDice()
        {
            turnCount++;

            // Roll dice process
            int roll1 = DieOne.Roll();
            int roll2 = DieSecond.Roll();

            int sum = roll1 + roll2;
            doPlayAgain = roll1 == roll2;

            // If number are the same player can re-roll dices
            if (doPlayAgain)
            {
                InfoBulle = "Double, Relancez!!";

                Reader(infoBulle);

                doubleDiceCount++;

                if (doubleDiceCount >= 3)
                {
                    //TODO send player to jail

                    SetNextPlayerTurn();
                }
            }
            else
            {
                InfoBulle = "Avancez de " + sum + " cases";
                Reader(infoBulle);
                SetNextPlayerTurn();
            }

            // Move player
            Cases[38].Players.Add(CurrentPlayer);
            Cases[39].Players.Remove(CurrentPlayer);

            // TODO Execute case action
        }

        private void SetNextPlayerTurn()
        {
            doubleDiceCount = 0;

            // Set next player as current
            CurrentPlayer = Players[turnCount % Players.Count];
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
