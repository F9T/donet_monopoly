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
    /// <summary>
    /// Base class for platter's cases model
    /// Every cases store his own players
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(EmptyCase))]
    [XmlInclude(typeof(PropertyCase))]
    [XmlInclude(typeof(StartCase))]
    [XmlInclude(typeof(TextImageCase))]
    public abstract class AbstractCase : IModel, INotifyPropertyChanged
    {
        private bool selected;      // Selected state
        protected Random random;    // Random provider

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AbstractCase()
        {
            //Default values
            Initialize();
        }

        /// <summary>
        /// Init base variables
        /// </summary>
        public void Initialize()
        {
            Players = new ObservableCollection<Player>();   // Init list to handle players who are on the case
            random = new Random(DateTime.Now.Millisecond);
            IsEditable = true;                              // Edition state
            Selected = false;
        }

        // ---------- Getter / Setters ----------

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

        // --------------------------------------

        /// <summary>
        /// Provide random model self initialization
        /// </summary>
        public abstract void RandomFill();

        /// <summary>
        /// Main event action of the case
        /// </summary>
        /// <param name="_player">current player</param>
        /// <param name="_platter">current platter with all game infos</param>
        public abstract void Action(Player _player, Platter _platter);

        /// <summary>
        /// Provide legal access on case
        /// </summary>
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