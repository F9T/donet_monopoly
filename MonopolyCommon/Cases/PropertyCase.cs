using System;
using System.Windows.Media;
using System.Xml.Serialization;

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

        [XmlIgnore]
        public SolidColorBrush Color
        {
            get => color;
            set
            {
                color = value;
                colorString = color.ToString();
                OnPropertyChanged(nameof(Color));
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

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
