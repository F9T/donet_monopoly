using System.Windows.Controls;
using MonopolyEditor.ViewModels;

namespace MonopolyEditor.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            DataContext = MainViewModel;
        }
        
        public MainViewModel MainViewModel { get; set; }

        private void ListView_OnSelectionChanged(object _sender, SelectionChangedEventArgs _e)
        {
            var listView = _sender as ListView;
            listView?.ScrollIntoView(MainViewModel.SelectedCase);
        }
    }
}
