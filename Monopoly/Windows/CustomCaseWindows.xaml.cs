using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monopoly.Models.Cases;

namespace Monopoly.Windows
{
    /// <summary>
    /// Logique d'interaction pour CustomCaseWindows.xaml
    /// </summary>
    public partial class CustomCaseWindows : INotifyPropertyChanged
    {
        public CustomCaseWindows()
        {
            InitializeComponent();
        }

        public AbstractCase Case { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
