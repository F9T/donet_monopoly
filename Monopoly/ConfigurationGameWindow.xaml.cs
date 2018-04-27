using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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
    }
}
