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

        public override void RandomFill()
        {
            var values = new[] { 50, 100, 150, 200, 250, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000 };
            Price = values[random.Next(0, values.Length)];
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
    }
}
