using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;
using System.Collections.ObjectModel;

namespace MonopolyCommon.Cases
{
    [Serializable]
    [XmlInclude(typeof(EmptyCase))]
    [XmlInclude(typeof(PropertyCase))]
    [XmlInclude(typeof(StartCase))]
    [XmlInclude(typeof(TextImageCase))]
    public abstract class AbstractCase : IModel, INotifyPropertyChanged
    {
        private bool selected;
        protected Random random;

        protected AbstractCase()
        {
            //Default values
            Initialize();
        }

        public void Initialize()
        {
            Players = new ObservableCollection<Player>();
            random = new Random(DateTime.Now.Millisecond);
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

        [XmlIgnore]
        public ObservableCollection<Player> Players { get; set; }

        public abstract void RandomFill();

        //Action de la case
        public abstract void Action(Player _player, Platter _platter);

        //On peut y aller ou pas
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