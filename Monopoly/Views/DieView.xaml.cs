using System;
using System.Windows;
using System.Windows.Input;

namespace Monopoly.Views
{
    /// <summary>
    /// Logique d'interaction pour DieView.xaml
    /// </summary>
    public partial class DieView
    {
        public DieView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DieProperty = DependencyProperty.Register("Die", typeof(Die), typeof(DieView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Die Die
        {
            get => (Die) GetValue(DieProperty);
            set => SetValue(DieProperty, value);
        }
    }
}
