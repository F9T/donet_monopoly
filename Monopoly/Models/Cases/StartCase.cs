using System;
using System.Xml.Serialization;

namespace Monopoly.Models.Cases
{
    [Serializable]
    public class StartCase : AbstractCase
    {
        public StartCase()
        {
            //Default values
            Text = "START";
        }

        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlAttribute("gain")]
        public int Gain { get; set; }

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
