using Monopoly.ViewModels;

namespace Monopoly
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            DataContext = MainViewModel;
        }

        private void Initialize()
        {
            MainViewModel = new MainViewModel();
        }

        public MainViewModel MainViewModel { get; set; }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
