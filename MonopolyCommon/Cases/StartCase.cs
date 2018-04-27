using System;
using System.Xml.Serialization;
using MonopolyCommon.Cases.Categories;

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
        public string Text
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

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
