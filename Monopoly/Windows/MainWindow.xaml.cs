using System.Windows;
using Monopoly.ViewModels;

namespace Monopoly.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            MainViewModel = new MainViewModel();
        }

        public MainViewModel MainViewModel { get; set; }
    }
}
