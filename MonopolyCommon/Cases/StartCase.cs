using System;
using System.Xml.Serialization;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class StartCase : AbstractCase
    {
        private int gain;
        private string text;

        public StartCase()
        {
            //Default values
            Text = "START";
            Type = "Start";
            IsEditable = false;
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
