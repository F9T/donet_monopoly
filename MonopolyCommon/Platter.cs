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
        private const int NumberCase = 40;

        private string pathFile;
        private Random random;

        public Platter()
        {
            random = new Random(DateTime.Now.Millisecond);
            Cases = new ObservableCollection<AbstractCase>();
            //Create start case
            //Default name
            PathFile = "platter.xml";
            AlreadySerialize = false;
        }

        public void FillDefaultCase()
        {
            Cases.Clear();
            for (int i = 0; i < NumberCase - 1; i++)
            {
                Cases.Add(new EmptyCase());
            }
            Cases.Add(new StartCase());
        }

        public void FillRandomCase()
        {
            FillDefaultCase();
         /*   Cases.Clear();
            var casesType = new []
            {
                typeof(PropertyCase), typeof(ChanceCase), typeof(JailCase), typeof(PropertyCase),
                typeof(ChestCase), typeof(PropertyCase), typeof(StationCase), typeof(TaxCase), typeof(PropertyCase),
                typeof(PropertyCase), typeof(PropertyCase)
            };
            int min = 0, max = casesType.Length;
            for (int i = 0; i < NumberCase - 1; i++)
            {
                var type = casesType[random.Next(min, max)];
                var randomCase =(AbstractCase) Activator.CreateInstance(type);
                randomCase.RandomFill();
                Cases.Add(randomCase);
            }
            Cases.Add(new StartCase());*/
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
