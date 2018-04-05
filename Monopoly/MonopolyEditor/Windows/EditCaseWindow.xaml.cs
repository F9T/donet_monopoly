using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MonopolyCommon.Cases;

namespace MonopolyEditor.Windows
{
    /// <summary>
    /// Logique d'interaction pour EditCaseWindow.xaml
    /// </summary>
    public partial class EditCaseWindow : INotifyPropertyChanged
    {
        private AbstractCase mcase;

        public EditCaseWindow()
        {
            InitializeComponent();
            DataContext = this;
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
