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
using System.Windows;
using System.Linq;

namespace Monopoly.ViewModels
{
    /// <summary>
    /// Main ViewModel for platter
    /// </summary>
    public class PlatterViewModel : IViewModel
    {
        // PositionIndex to Cases position in WPF
        IDictionary<int, int> posToWPF = new Dictionary<int, int>();

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

            FillPosToWPF();
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

            // Move
            AbstractCase currentCase = Cases[CurrentPlayer.CurrentCaseIndex];
            CurrentPlayer.CurrentCaseIndex = CalculateNextCase(CurrentPlayer.CurrentCaseIndex, sum);
            AbstractCase nextCase = Cases[CurrentPlayer.CurrentCaseIndex];

            currentCase.Players.Remove(CurrentPlayer);
            nextCase.Players.Add(CurrentPlayer);

            // Execute case action
            string result = nextCase.Action(CurrentPlayer, (Platter)Model);
            if(nextCase.GetType() == typeof(PropertyCase) || nextCase.GetType() == typeof(StationCase)) {
                MsgBoxYesNo msgbox = new MsgBoxYesNo(result);
                if ((bool)msgbox.ShowDialog())
                {
                    // Todo Buy property
                }
            }
            else
                new MsgBoxOk(result).ShowDialog();

        }

        private int CalculateNextCase(int firstCaseIndex, int sum)
        {
            int firstCasePos = posToWPF.FirstOrDefault(x => x.Value == firstCaseIndex).Key;
            return posToWPF[(firstCasePos + sum) % 40];
        }

        private void SetNextPlayerTurn()
        {
            doubleDiceCount = 0;

            // Set next player as current
            CurrentPlayer = Players[turnCount % Players.Count];
        }

        private void FillPosToWPF()
        {
            // So ugly but need to be done manually due to editor mapping. Externalize it
            posToWPF.Add(0, 39);

            posToWPF.Add(1, 38);
            posToWPF.Add(2, 37);
            posToWPF.Add(3, 36);
            posToWPF.Add(4, 35);
            posToWPF.Add(5, 34);
            posToWPF.Add(6, 33);
            posToWPF.Add(7, 32);
            posToWPF.Add(8, 31);
            posToWPF.Add(9, 30);

            posToWPF.Add(10, 29);

            posToWPF.Add(11, 27);
            posToWPF.Add(12, 25);
            posToWPF.Add(13, 23);
            posToWPF.Add(14, 21);
            posToWPF.Add(15, 19);
            posToWPF.Add(16, 17);
            posToWPF.Add(17, 15);
            posToWPF.Add(18, 13);
            posToWPF.Add(19, 11);

            posToWPF.Add(20, 0);

            posToWPF.Add(21, 1);
            posToWPF.Add(22, 2);
            posToWPF.Add(23, 3);
            posToWPF.Add(24, 4);
            posToWPF.Add(25, 5);
            posToWPF.Add(26, 6);
            posToWPF.Add(27, 7);
            posToWPF.Add(28, 8);
            posToWPF.Add(29, 9);

            posToWPF.Add(30, 10);

            posToWPF.Add(31, 12);
            posToWPF.Add(32, 14);
            posToWPF.Add(33, 16);
            posToWPF.Add(34, 18);
            posToWPF.Add(35, 20);
            posToWPF.Add(36, 22);
            posToWPF.Add(37, 24);
            posToWPF.Add(38, 26);
            posToWPF.Add(39, 28);
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

            //Set player cases
            foreach (var player in Players)
            {
                player.CurrentCaseIndex = 39;
            }

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
