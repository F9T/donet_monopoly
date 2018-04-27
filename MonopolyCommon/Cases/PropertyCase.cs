using System;
using System.Windows.Media;
using System.Xml.Serialization;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class PropertyCase : AbstractCase
    {
        private SolidColorBrush color;
        private string colorString;
        private string propertyName;
        private int price;

        public PropertyCase()
        {
            Type = "Property";
        }

        public override void RandomFill()
        {
            var values = new[] { 50, 100, 150, 200, 250, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000 };
            Price = values[random.Next(0, values.Length)];
            Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255)));
        }

        [XmlIgnore]
        public SolidColorBrush Color
        {
            get => color;
            set
            {
                color = value;
                colorString = color.ToString();
                OnPropertyChanged(nameof(Color));
                OnPropertyChanged(nameof(ColorString));
            }
        }

        [XmlAttribute("color")]
        public string ColorString
        {
            get => colorString;
            set
            {
                colorString = value; 
                color = (SolidColorBrush) new BrushConverter().ConvertFrom(colorString);
                OnPropertyChanged(nameof(ColorString));
                OnPropertyChanged(nameof(Color));
            }
        }

        [XmlAttribute("property_name")]
        public string PropertyName
        {
            get => propertyName;
            set
            {
                propertyName = value;
                OnPropertyChanged(nameof(PropertyName));
            }
        }

        [XmlAttribute("price")]
        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public override void Action(Player _player, Platter _platter)
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
