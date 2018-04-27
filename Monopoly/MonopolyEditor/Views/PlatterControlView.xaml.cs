using System.Windows;
using System.Windows.Input;

namespace MonopolyEditor.Views
{
    /// <summary>
    /// Logique d'interaction pour PlatterControlView.xaml
    /// </summary>
    public partial class PlatterControlView
    {
        public PlatterControlView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CaseMinWidthProperty = DependencyProperty.Register("CaseMinWidth", typeof(int), typeof(PlatterControlView));
        public static readonly DependencyProperty CaseMinHeightProperty = DependencyProperty.Register("CaseMinHeight", typeof(int), typeof(PlatterControlView));

        public int CaseMinWidth
        {
            get => (int)GetValue(CaseMinWidthProperty);
            set => SetValue(CaseMinWidthProperty, value);
        }

        public int CaseMinHeight
        {
            get => (int)GetValue(CaseMinHeightProperty);
            set => SetValue(CaseMinHeightProperty, value);
        }
    }
}
