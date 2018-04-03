using System;
using System.Xml.Serialization;

namespace Monopoly.Models.Cases.Categories
{
    [Serializable]
    [XmlInclude(typeof(TaxCase))]
    [XmlInclude(typeof(StationCase))]
    public abstract class PriceTextImageCase : TextImageCase
    {
        [XmlAttribute("price")]
        public int Price { get; set; }
    }
}
