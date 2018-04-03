using System;
using System.Xml.Serialization;

namespace Monopoly.Models.Cases
{
    [Serializable]
    [XmlInclude(typeof(ChanceCase))]
    [XmlInclude(typeof(JailCase))]
    [XmlInclude(typeof(ChestCase))]
    public abstract class TextImageCase : AbstractCase
    {
        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlAttribute("image_path")]
        public string ImagePath { get; set; }
    }
}
