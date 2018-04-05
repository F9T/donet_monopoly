using System;
using System.Xml.Serialization;

namespace MonopolyCommon.Cases.Categories
{
    [Serializable]
    [XmlInclude(typeof(TaxCase))]
    [XmlInclude(typeof(StationCase))]
    public abstract class PriceTextImageCase : TextImageCase
    {
        private int price;

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
    }
}
