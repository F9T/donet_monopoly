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
        /// <summary>
        /// This function initialize the game
        /// user list, color for each user
        /// </summary>
        public void Initialize()
        {
            Players = new ObservableCollection<Player>();
            PathGame = "";

            //Availables colors
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

        /// <summary>
        /// Function use to add new user
        /// </summary>
        public void AddPlayer()
        {
            var color = GetNotChooseColor();
            if (color == null)
            {
                MessageBox.Show("Fatal color choose error!");
                return;
            }

            var player = new Player("new player", color);
            Players.Add(player);
            SelectedPlayer = player;
        }

        /// <summary>
        /// Choose a color for new user. The color must not be already  choose
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Remove selected player to the list
        /// </summary>
        public void DeleteSelectedPlayer()
        {
            if (SelectedPlayer != null)
            {
                Players.Remove(SelectedPlayer);
                SelectedPlayer = null;
            }
        }

        /// <summary>
        /// Maximum of 6 players for the game
        /// </summary>
        /// <returns></returns>
        public bool CanAddPlayer()
        {
            return Players.Count < 6;
        }

        //Path of platter (xml file)
        public string PathGame { get; set; }

        //Collection of color for player
        public ObservableCollection<ColorItem> AvailableColors { get; set; }

        //Colelction of players
        public ObservableCollection<Player> Players { get; set; }

        //Selected player
        public Player SelectedPlayer { get; set; }

        public void Dispose()
        {
        }
    }
}