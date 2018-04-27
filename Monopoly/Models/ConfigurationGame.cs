using System;
using System.Collections.Generic;
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
            PathGame = "";

            //Limit colors use for players
            AvailableColors = new ObservableCollection<ColorItem>
            {
                new ColorItem(Colors.Blue, "Blue"),
                new ColorItem(Colors.Red, "Red"),
                new ColorItem(Colors.Yellow, "Yellow"),
                new ColorItem(Colors.Green, "Green"),
                new ColorItem(Colors.Orange, "Orange"),
                new ColorItem(Colors.Purple, "Purple")
            };
        }

        public void AddPlayer()
        {
            var color = GetNotChooseColor();
            if (color == null)
            {
                MessageBox.Show("Fatal color choose error!");
                return;
            }
            var player = new Player("no name", color);
            Players.Add(player);
            SelectedPlayer = player;
        }

        private SolidColorBrush GetNotChooseColor()
        {
            var copyAvailableColor = new List<ColorItem>(AvailableColors);
            foreach (var player in Players)
            {
                var colorPlayer = player.Color.Color;
                for (int i = 0; i < copyAvailableColor.Count; i++)
                {
                    var colorItem = copyAvailableColor[i];
                    var color = colorItem.Color;
                    if (color != null && color.Value == colorPlayer)
                    {
                        copyAvailableColor.RemoveAt(i);
                        break;
                    }
                }
            }
            if (copyAvailableColor.Count > 0)
            {
                var color = copyAvailableColor[0].Color;
                if (color != null) return new SolidColorBrush(color.Value);
            }
            return null;
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

        public string PathGame { get; set; }

        public ObservableCollection<ColorItem> AvailableColors { get; set; }

        public ObservableCollection<Player> Players { get; set; }

        public Player SelectedPlayer { get; set; }

        public void Dispose()
        {
        }
    }
}