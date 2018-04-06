using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MonopolyCommon;
using MonopolyCommon.Cases;

namespace MonopolyEditor.Windows
{
    /// <summary>
    /// Logique d'interaction pour EditCaseWindow.xaml
    /// </summary>
    public partial class EditCaseWindow : INotifyPropertyChanged
    {
        private AbstractCase mcase;
        private string selectedCaseType;

        public EditCaseWindow()
        {
            InitializeComponent();
            DataContext = this;

            ChangeCaseCommand = new RelayCommand(_param => ChangeType(), _param => true);

            TypeCases = new ObservableCollection<string> { "", "Empty", "Chance", "Chest", "Jail", "Property", "Station", "Tax" };
            SelectedCaseType = TypeCases.First();
        }

        private void ChangeType()
        {
            switch (SelectedCaseType.ToLower())
            {
                case "empty":
                    Case = new EmptyCase();
                    break;
                case "property":
                    Case = new PropertyCase();
                    break;
                case "chance":
                    Case = new ChanceCase();
                    break;
                case "chest":
                    Case = new ChestCase();
                    break;
                case "jail":
                    Case = new JailCase();
                    break;
                case "station":
                    Case = new StationCase();
                    break;
                case "tax":
                    Case = new TaxCase();
                    break;
            }
        }

        public AbstractCase Case
        {
            get => mcase;
            set
            {
                mcase = value;
                OnPropertyChanged(nameof(Case));
            }
        }

        public string SelectedCaseType
        {
            get => selectedCaseType;
            set
            {
                selectedCaseType = value;
                OnPropertyChanged(nameof(SelectedCaseType));
            }
        }
        
        public ICommand ChangeCaseCommand { get; set; }
        public ObservableCollection<string> TypeCases { get; set; }

        private void Ok_OnClick(object _sender, RoutedEventArgs _e)
        {
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));

        }
    }
}
