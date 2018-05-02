using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monopoly.ViewModels;

namespace Monopoly
{
    /// <summary>
    /// Logique d'interaction pour ConfigurationGameWindow.xaml
    /// </summary>
    public partial class ConfigurationGameWindow : INotifyPropertyChanged
    {
        private ConfigurationGameViewModel configurationGameViewModel;

        public ConfigurationGameWindow()
        {
            InitializeComponent();
            ConfigurationGameViewModel = new ConfigurationGameViewModel();
            DataContext = ConfigurationGameViewModel;
        }

        public ConfigurationGameViewModel ConfigurationGameViewModel
        {
            get => configurationGameViewModel;
            set
            {
                configurationGameViewModel = value;
                OnPropertyChanged(nameof(ConfigurationGameViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }

        private void PlayerEditView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void PlayerEditView_Loaded_1(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
