using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MonopolyCommon;
using MonopolyCommon.Interfaces;
using MonopolyCommon.Players;
using Monopoly.Views;

namespace Monopoly.ViewModels
{
    public class MainViewModel : AbstractFileManager
    {
        private PlatterViewModel platterViewModel;


        public MainViewModel()
        {
            PlatterViewModel = new PlatterViewModel();
            //PlatterViewModel.Deserialize(@"D:\HE-ARC\DotNet\Projets\monopoly\classic.xml");

            NewGameCommand = new RelayCommand(_param => New(), _param => true);

            QuitGameCommand = new RelayCommand(_param => Close());
        }

        protected override void New()
        {
            var configPlayers = new ConfigurationGameWindow
            {
                Owner = Application.Current.MainWindow
            };
            configPlayers.ShowDialog();
            if (!configPlayers.ConfigurationGameViewModel.IsCancelled)
            {
                var pathGame = configPlayers.ConfigurationGameViewModel.PathGame;
                PlatterViewModel.AddPlayers(new ObservableCollection<Player>(configPlayers.ConfigurationGameViewModel.Players));
                PlatterViewModel.Deserialize(pathGame);
            }
        }

        /// <summary>
        /// Close application when user click to quit menu
        /// </summary>
        public void CloseWin()
        {
            MsgBoxYesNo msgbox = new MsgBoxYesNo("Êtes vous certain de vouloir quitter le jeu?");
            if ((bool)msgbox.ShowDialog())
            {
                Application.Current.Shutdown();
            }

        }

        protected override bool Close()
        {
            CloseWin();
            return true;
        }

        protected override void Load() { }

        protected override void Save() { }

        protected override void SaveAs(){ }

        public IModel Model { get; set; }

        public PlatterViewModel PlatterViewModel
        {
            get => platterViewModel;
            set
            {
                platterViewModel = value;
                OnPropertyChanged(nameof(PlatterViewModel));
            }
        }

        public ICommand NewGameCommand { get; set; }

        /// <summary>
        /// The command for when user click to quit button
        /// </summary>
        public ICommand QuitGameCommand { get; set; }

        public void Dispose()
        {
        }
        
    }
}
