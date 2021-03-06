﻿using System;
using System.Xml.Serialization;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class StartCase : PriceTextImageCase
    {
        private int gain;
        private string text;

        public StartCase()
        {
            //Default values
            Text = "START";
            Type = "Start";
            Gain = 200;
            IsEditable = false;
        }

        public override void RandomFill()
        {
            var values = new[] {50, 100, 150, 200, 250, 350, 400};
            Gain = values[random.Next(0, values.Length)];
        }

        [XmlAttribute("text")]
        public new string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        [XmlAttribute("gain")]
        public int Gain
        {
            get => gain;
            set
            {
                gain = value;
                OnPropertyChanged(nameof(Gain));
            }
        }

        public override string Action(Player _player, Platter _platter)
        {
            _player.Balance += Gain;
            return "Bravo, vous êtes tombé sur la case départ, vous recevez le double du salaire";
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
