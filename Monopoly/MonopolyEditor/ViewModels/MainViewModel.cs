using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using MonopolyCommon;
using MonopolyCommon.Cases;
using MonopolyEditor.Windows;

namespace MonopolyEditor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        private AbstractCase selectedCase;
        private string selectedCaseType;
        private bool isCreated, isSaved;
        private Platter platter;

        public MainViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            IsCreated = false;
            IsSaved = false;

            NewCommand = new RelayCommand(_param => New(), _param => true);
            CloseCommand = new RelayCommand(_param => Close(), _param => IsCreated);
            SaveCommand = new RelayCommand(_param => Save(), _param => IsCreated);
            SaveAsCommand = new RelayCommand(_param => SaveAs(), _param => IsCreated);
            LoadCommand = new RelayCommand(_param => Load(), _param => true);
            ExitCommand = new RelayCommand(_param => Exit(), _param => true);

            NewCaseCommand = new RelayCommand(_param => NewCase(), _param => !SelectedCaseType.Equals("") && Platter != null && Platter.Cases.Count < 40);
            RemoveCaseCommand = new RelayCommand(_param => RemoveCase(), _param => IsCreated && SelectedCase != null);
            EditCaseCommand = new RelayCommand(_param => EditCase(), _param => IsCreated && SelectedCase != null);

            UpCaseCommand = new RelayCommand(_param => UpCase(), _param => IsCreated && SelectedCase != null);
            DownCaseCommand = new RelayCommand(_param => DownCase(), _param => IsCreated && SelectedCase != null);

            TypeCases = new ObservableCollection<string> {"", "Chance", "Chest", "Jail", "Property", "Station", "Tax"};
            SelectedCaseType = TypeCases.First();
        }

        private void New()
        {
            Close();
            IsCreated = true;
            Platter = new Platter();
            SelectedCaseType = TypeCases.First();
        }

        private void Close()
        {
            //If already create and not saved
            if (IsCreated && !IsSaved)
            {
                var result = MessageBox.Show($"Save file {Platter.PathFile} ?", "Confirmation", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    if (!Platter.AlreadySerialize)
                    {
                        SaveAs();
                    }
                    if (new FileInfo(Platter.PathFile).Exists)
                    {
                        PlatterSerializer.Serialize(Platter);
                        Reset();
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    Reset();
                }
            }
            else if (IsCreated && IsSaved)
            {
                Reset();
            }
        }

        private void Reset()
        {
            IsCreated = false;
            IsSaved = false;
            Platter = null;
            SelectedCase = null;
            SelectedCaseType = TypeCases.First();
        }

        private void Save()
        {
            if (!Platter.AlreadySerialize)
            {
                SaveAs();
            }
            if (new FileInfo(Platter.PathFile).Exists)
            {
                PlatterSerializer.Serialize(Platter);
            }
        }

        private void SaveAs()
        {
            var saveDialog = new SaveFileDialog { Filter = "XML Files (*.xml)| *.xml" };
            var result2 = saveDialog.ShowDialog(Application.Current.MainWindow);
            if (result2 == true)
            {
                Platter.PathFile = saveDialog.FileName;
            }
        }

        private void Load()
        {
            Close();
            var fileDialog = new OpenFileDialog {Filter = "XML Files (*.xml)| *.xml", Multiselect = false};
            var dial = fileDialog.ShowDialog(Application.Current.MainWindow);
            if (dial == true)
            {
                var fileInfo = new FileInfo(fileDialog.FileName);
                if (fileInfo.Exists)
                {
                    Platter = PlatterSerializer.Deserialize(fileInfo.FullName);
                    if (Platter != null)
                    {
                        IsCreated = true;
                        IsSaved = true;
                    }
                }
            }
        }

        private void Exit()
        {
            Close();
            Dispose();
            Application.Current.Shutdown(0);
        }

        private void NewCase()
        {
            switch (SelectedCaseType.ToLower())
            {
                case "property":
                    Platter.Cases.Add(new PropertyCase());
                    break;
                case "chance":
                    Platter.Cases.Add(new ChanceCase());
                    break;
                case "chest":
                    Platter.Cases.Add(new ChestCase());
                    break;
                case "jail":
                    Platter.Cases.Add(new JailCase());
                    break;
                case "station":
                    Platter.Cases.Add(new StationCase());
                    break;
                case "tax":
                    Platter.Cases.Add(new TaxCase());
                    break;
            }
            SelectedCase = Platter.Cases.Last();
            IsSaved = false;
        }

        private void EditCase()
        {
            var editWindow = new EditCaseWindow {Owner = Application.Current.MainWindow, Case = SelectedCase};
            editWindow.ShowDialog();
        }

        private void RemoveCase()
        {
            Platter.Cases.Remove(SelectedCase);
            SelectedCase = null;
            IsSaved = false;
        }

        private void UpCase()
        {
            var tmpCase = SelectedCase;
            int index = Platter.Cases.IndexOf(tmpCase);
            if (index > 0)
            {
                Platter.Cases.Remove(tmpCase);
                Platter.Cases.Insert(index - 1, tmpCase);
                SelectedCase = tmpCase;
            }
        }

        private void DownCase()
        {
            var tmpCase = SelectedCase;
            int index = Platter.Cases.IndexOf(tmpCase);
            if (index < Platter.Cases.Count - 1)
            {
                Platter.Cases.Remove(tmpCase);
                Platter.Cases.Insert(index + 1, tmpCase);
                SelectedCase = tmpCase;
            }
        }

        public ICommand NewCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand NewCaseCommand { get; set; }
        public ICommand RemoveCaseCommand { get; set; }
        public ICommand EditCaseCommand { get; set; }
        public ICommand UpCaseCommand { get; set; }
        public ICommand DownCaseCommand { get; set; }

        public ObservableCollection<string> TypeCases { get; set; }

        public Platter Platter
        {
            get => platter;
            set
            {
                platter = value;
                OnPropertyChanged(nameof(Platter));
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

        public AbstractCase SelectedCase
        {
            get => selectedCase;
            set
            {
                if (selectedCase != null)
                {
                    selectedCase.Selected = false;
                }
                selectedCase = value;
                if (selectedCase != null)
                {
                    selectedCase.Selected = true;
                }
                OnPropertyChanged(nameof(SelectedCase));
            }
        }

        public bool IsCreated
        {
            get => isCreated;
            set
            {
                isCreated = value;
                OnPropertyChanged(nameof(IsCreated));
            }
        }

        public bool IsSaved
        {
            get => isSaved;
            set
            {
                isSaved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }

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
