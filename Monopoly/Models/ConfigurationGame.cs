using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;
using Xceed.Wpf.Toolkit;

namespace Monopoly.Models
{
    [Serializable]
    public class ConfigurationGame : IModel
    {
        public ConfigurationGame()
        {
            Initialize();
        }

        public void Initialize()
        {
            Players = new ObservableCollection<Player>();

            //Limit colors use for players
            AvailableColors = new ObservableCollection<ColorItem>();
            AvailableColors = new ObservableCollection<ColorItem>();
            AvailableColors.Add(new ColorItem(Colors.Blue, "Blue"));
            AvailableColors.Add(new ColorItem(Colors.Red, "Red"));
            AvailableColors.Add(new ColorItem(Colors.Yellow, "Yellow"));
            AvailableColors.Add(new ColorItem(Colors.Green, "Green"));
            AvailableColors.Add(new ColorItem(Colors.Navy, "Navy"));
        }

        public void AddPlayer()
        {
            var player = new Player("test", new SolidColorBrush(Colors.Aqua), 100);
            Players.Add(player);
            SelectedPlayer = player;
        }

        public void DeleteSelectedPlayer()
        {
            if (SelectedPlayer != null)
            {
                Players.Remove(SelectedPlayer);
                SelectedPlayer = null;
            }
        }

        public bool CanAddPlayer()
        {
            return Players.Count < 6;
        }

        public ObservableCollection<ColorItem> AvailableColors { get; set; }

        public ObservableCollection<Player> Players { get; set; }

        public Player SelectedPlayer { get; set; }

        public void Dispose()
        {
            
        }
    }
}
