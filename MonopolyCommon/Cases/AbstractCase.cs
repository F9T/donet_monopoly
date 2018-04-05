using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon.Cases
{
    [Serializable]
    [XmlInclude(typeof(PropertyCase))]
    [XmlInclude(typeof(StartCase))]
    [XmlInclude(typeof(TextImageCase))]
    public abstract class AbstractCase : IModel, INotifyPropertyChanged
    {
        private bool selected;

        protected AbstractCase()
        {
            //Default values
            Initialize();
        }

        public void Initialize()
        {
            IsEditable = true;
            Selected = false;
        }

        [XmlIgnore]
        public bool IsEditable { get; set; }

        [XmlIgnore]
        public bool Selected
        {
            get => selected;
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        [XmlIgnore]
        public string Type { get; set; }

        [XmlIgnore]
        public int Width { get; set; }

        [XmlIgnore]
        public int Height { get; set; }

        public abstract void Action();

        public abstract bool IsLegal();

        public void Dispose()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}