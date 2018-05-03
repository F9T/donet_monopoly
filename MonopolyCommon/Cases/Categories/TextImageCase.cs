using System;
using System.Xml.Serialization;

namespace MonopolyCommon.Cases.Categories
{
    [Serializable]
    [XmlInclude(typeof(PriceTextImageCase))]
    [XmlInclude(typeof(ChanceCase))]
    [XmlInclude(typeof(JailCase))]
    [XmlInclude(typeof(ChestCase))]
    [XmlInclude(typeof(FreeJail))]
    [XmlInclude(typeof(ParkingCase))]
    public abstract class TextImageCase : AbstractCase
    {
        private string text;
        private string imagePath;

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

        [XmlAttribute("image_path")]
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
    }
}
