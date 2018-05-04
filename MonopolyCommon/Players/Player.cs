using MonopolyCommon.Cases;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MonopolyCommon.Players
{
    /// <summary>
    /// Model to handle a player data
    /// </summary>
    [Serializable]
    public class Player : INotifyPropertyChanged
    {
        private SolidColorBrush color;      // Associated color
        private string name, colorString;
        private int balance, initBalance;   // Money of the player
        private AbstractCase currentCase;

        /// <summary>
        /// Default constructor for serialization
        /// </summary>
        public Player()
        {
            
        }

        /// <summary>
        /// Complete constructor for player
        /// </summary>
        /// <param name="_name">player name</param>
        /// <param name="_color">player color</param>
        /// <param name="_initBalance">player's start cash/money/balance</param>
        public Player(string _name, SolidColorBrush _color, int _initBalance = 1500)
        {
            Name = _name;
            Color = _color;
            Balance = _initBalance;
            InitBalance = _initBalance;
        }

        // --------- Getters / Setters ----------

        [XmlIgnore]
        public SolidColorBrush Color
        {
            get => color;
            set
            {
                color = value;
                colorString = color.ToString();
                OnPropertyChanged(nameof(Color));
                OnPropertyChanged(nameof(ColorString));
            }
        }

        [XmlAttribute("color")]
        public string ColorString
        {
            get => colorString;
            set
            {
                colorString = value;
                color = (SolidColorBrush)new BrushConverter().ConvertFrom(colorString);
                OnPropertyChanged(nameof(ColorString));
                OnPropertyChanged(nameof(Color));
            }
        }

        [XmlAttribute("name")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [XmlAttribute("init_balance")]
        public int InitBalance
        {
            get => initBalance;
            set
            {
                initBalance = value;
                balance = value;
                OnPropertyChanged(nameof(InitBalance));
                OnPropertyChanged(nameof(Balance));
            }
        }

        [XmlIgnore]
        public int Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        [XmlIgnore]
        public AbstractCase CurrentCase
        {
            get
            {
                return currentCase;
            }
            set
            {
                currentCase = value;
            }
        }

        // --------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
