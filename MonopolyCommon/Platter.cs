using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using MonopolyCommon.Cases;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;

namespace MonopolyCommon
{
    /// <summary>
    /// Model class to handle platter and player data
    /// </summary>
    [Serializable]
    public class Platter : IModel
    {
        // Total number of cases
        private const int NumberCase = 40;

        // Random Generator
        private Random random;

        /// <summary>
        /// Default initializer.
        /// Used be editor
        /// </summary>
        public Platter()
        {
            Initialize();
        }

        /// <summary>
        /// Game platter initializer with players and cases
        /// </summary>
        public void Initialize()
        {
            random = new Random(DateTime.Now.Millisecond);      //Just initialize random generator

            // Init game
            Cases = new ObservableCollection<AbstractCase>();   //Observable list to handle cases
            Players = new ObservableCollection<Player>();       //Observable list to handle players
            IsStarted = false;

            //Create start case
            //Default name

            // Set save/load variables
            PathFile = "";
            AlreadySerialize = false;
            
        }

        /// <summary>
        /// Fill the default cases :
        /// -Start
        /// -Parking
        /// -Jail
        /// -FreeJail
        /// </summary>
        public void FillDefaultCase()
        {
            Cases.Clear();
            for (var i = 0; i < NumberCase - 1; i++)
            {
                AbstractCase createCase = new EmptyCase();
                switch (i)
                {
                    case 0:
                        createCase = new ParkingCase();
                        break;
                    case 10:
                        createCase = new JailCase();
                        break;
                    case 29:
                        createCase = new FreeJail();
                        break;
                }
                Cases.Add(createCase);
            }
            Cases.Add(new StartCase());
        }

        /// <summary>
        /// Method to fill random cases
        /// </summary>
        public void FillRandomCase()
        {
            FillDefaultCase();
            Cases.Clear();
            var casesType = new[]
            {
                typeof(PropertyCase), typeof(ChanceCase), typeof(PropertyCase),
                typeof(ChestCase), typeof(PropertyCase), typeof(StationCase), typeof(TaxCase), typeof(PropertyCase),
                typeof(PropertyCase), typeof(PropertyCase)
            };
            int min = 0, max = casesType.Length;
            for (int i = 0; i < NumberCase - 1; i++)
            {
                if (i == 0)
                {
                    Cases.Add(new ParkingCase());

                } 
                else if (i == 10)
                {

                    Cases.Add(new JailCase());
                }
                else if (i == 29)
                {
                    Cases.Add(new FreeJail());
                }
                else
                {
                    var type = casesType[random.Next(min, max)];
                    var randomCase = (AbstractCase)Activator.CreateInstance(type);
                    randomCase.RandomFill();
                    Cases.Add(randomCase);
                }
            }
            Cases.Add(new StartCase());
        }

        /// <summary>
        /// Serizalize object to provide save file exportation
        /// </summary>
        /// <param name="_path">path of the file</param>
        public void Serialize(string _path)
        {
            var platter = PlatterSerializer.Deserialize(_path);
            Cases = new ObservableCollection<AbstractCase>(platter.Cases);

            PathFile = platter.PathFile;
            IsStarted = true;

            //All players in starting block
            Cases[39].Players = new ObservableCollection<Player>(Players);
        }

        // --------- Getters / Setters ----------

        [XmlIgnore]
        public bool IsStarted { get; set; }

        [XmlIgnore]
        public Player CurrentPlayer { get; set; }

        [XmlArray(ElementName = "Cases")]
        [XmlArrayItem("Case", Type = typeof(AbstractCase))]
        public ObservableCollection<AbstractCase> Cases { get; set; }

        [XmlArray(ElementName = "Players")]
        [XmlArrayItem("Player", Type = typeof(Player), IsNullable = true)]
        public ObservableCollection<Player> Players { get; set; }

        [XmlIgnore]
        public string PathFile { get; set; }

        [XmlIgnore]
        public bool AlreadySerialize { get; set; }

        // --------------------------------------

        public void Dispose()
        {
        }

        // Delegate
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}