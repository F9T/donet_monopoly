using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using MonopolyCommon.Cases;

namespace MonopolyCommon
{
    [Serializable]
    public class Platter : INotifyPropertyChanged
    {
        private string pathFile;

        public Platter()
        {
            Cases = new ObservableCollection<AbstractCase> {new StartCase()};
            //Create start case
            //Default name
            PathFile = "platter.xml";
            AlreadySerialize = false;
        }

        [XmlArray(ElementName = "Cases")]
        [XmlArrayItem("Case", Type = typeof(AbstractCase))]
        public ObservableCollection<AbstractCase> Cases { get; set; }

        [XmlIgnore]
        public string PathFile
        {
            get => pathFile;
            set
            {
                pathFile = value;
                OnPropertyChanged(nameof(PathFile));
            }
        }
        [XmlIgnore]
        public bool AlreadySerialize { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
