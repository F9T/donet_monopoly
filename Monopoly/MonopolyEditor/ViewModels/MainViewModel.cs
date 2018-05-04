using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using MonopolyCommon;
using MonopolyCommon.Cases;
using MonopolyEditor.Windows;

namespace MonopolyEditor.ViewModels
{
    public class MainViewModel : AbstractFileManager, IDisposable
    {
        private AbstractCase selectedCase;
        private Platter platter;

        public MainViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            NewCommand = new RelayCommand(_param => New(), _param => true);
            CloseCommand = new RelayCommand(_param => Close(), _param => IsCreated);
            SaveCommand = new RelayCommand(_param => Save(), _param => IsCreated);
            SaveAsCommand = new RelayCommand(_param => SaveAs(), _param => IsCreated);
            LoadCommand = new RelayCommand(_param => Load(), _param => true);
            ExitCommand = new RelayCommand(_param => Exit(), _param => true);

            RemoveCaseCommand = new RelayCommand(_param => RemoveCase(), _param => IsCreated && SelectedCase != null);
            EditCaseCommand = new RelayCommand(_param => EditCase(), _param => IsCreated && SelectedCase != null);

            UpCaseCommand = new RelayCommand(_param => UpCase(), _param => IsCreated && SelectedCase != null);
            DownCaseCommand = new RelayCommand(_param => DownCase(), _param => IsCreated && SelectedCase != null);

            GenerateClassicGameCommand = new RelayCommand(_param => Generate(EnumGenerateGameType.Classic), _param => true);
            GenerateRandomGameCommand = new RelayCommand(_param => Generate(EnumGenerateGameType.Random), _param => true);
        }

        private void Generate(EnumGenerateGameType _gameType)
        {
            var cancel = Close();
            if (cancel)
            {
                return;
            }
            switch (_gameType)
            {
                case EnumGenerateGameType.Classic:
                    //TODO
                    break;
                case EnumGenerateGameType.Random:
                    IsCreated = true;
                    Platter = new Platter();
                    Platter.FillRandomCase();
                    break;
            }
        }

        
        protected override void New()
        {
            var cancel = Close();
            if (cancel)
            {
                return;
            }
            IsCreated = true;
            Platter = new Platter();
            Platter.FillDefaultCase();
        }

        protected override bool Close()
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
                else
                {
                    return true;
                }
            }
            else if (IsCreated && IsSaved)
            {
                Reset();
            }
            return false;
        }

        private void Reset()
        {
            IsCreated = false;
            IsSaved = false;
            Platter = null;
            SelectedCase = null;
        }

        protected override void Save()
        {
            if (!Platter.AlreadySerialize)
            {
                SaveAs();
            }
            var directoryInfo = new FileInfo(Platter.PathFile).Directory;
            if (directoryInfo != null && directoryInfo.Exists)
            {
                PlatterSerializer.Serialize(Platter);
            }
        }

        protected override void SaveAs()
        {
            var saveDialog = new SaveFileDialog { Filter = "XML Files (*.xml)| *.xml" };
            var result2 = saveDialog.ShowDialog(Application.Current.MainWindow);
            if (result2 == true)
            {
                Platter.PathFile = saveDialog.FileName;
            }
        }

        protected override void Load()
        {
            var cancel = Close();
            if (cancel)
            {
                return;
            }
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

        public bool Exit()
        {
            var cancel = Close();
            if (cancel)
            {
                return false;
            }
            Dispose();
            Application.Current.Shutdown(0);
            return true;
        }

        private void EditCase()
        {
            var editWindow = new EditCaseWindow {Owner = Application.Current.MainWindow, Case = SelectedCase};
            editWindow.ShowDialog();
            int index = Platter.Cases.IndexOf(SelectedCase);
            Platter.Cases.RemoveAt(index);
            Platter.Cases.Insert(index, editWindow.Case);
        }

        private void RemoveCase()
        {
            int index = Platter.Cases.IndexOf(SelectedCase);
            Platter.Cases.Remove(SelectedCase);
            Platter.Cases.Insert(index, new EmptyCase());
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
        public ICommand GenerateClassicGameCommand { get; set; }
        public ICommand GenerateRandomGameCommand { get; set; }

        public Platter Platter
        {
            get => platter;
            set
            {
                platter = value;
                OnPropertyChanged(nameof(Platter));
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

        public void Dispose()
        {

        }
    }
}
