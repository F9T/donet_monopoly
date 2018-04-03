using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Monopoly.Models.Cases
{
    [Serializable]
    public class PropertyCase : AbstractCase
    {
        private SolidColorBrush color;
        private string colorString;

        [XmlIgnore]
        public SolidColorBrush Color
        {
            get => color;
            set
            {
                color = value;
                colorString = color.ToString();
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
            }
        }

        [XmlAttribute("property_name")]
        public string PropertyName { get; set; }

        [XmlAttribute("price")]
        public int Price { get; set; }

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
