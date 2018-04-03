using System;
using System.Xml.Serialization;
using Monopoly.Interfaces;

namespace Monopoly.Models.Cases
{
    [Serializable]
    [XmlInclude(typeof(PropertyCase))]
    [XmlInclude(typeof(StartCase))]
    [XmlInclude(typeof(TextImageCase))]
    public abstract class AbstractCase : IModel
    {
        protected AbstractCase()
        {
            //Default values
        }

        [XmlIgnore]
        public int Width { get; set; }

        [XmlIgnore]
        public int Height { get; set; }

        public abstract void Action();

        public abstract bool IsLegal();

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
    }
}