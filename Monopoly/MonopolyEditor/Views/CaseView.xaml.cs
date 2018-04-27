using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MonopolyCommon.Cases;
using MonopolyEditor.ViewModels;

namespace MonopolyEditor.Views
{
    /// <summary>
    /// Logique d'interaction pour CaseView.xaml
    /// </summary>
    public partial class CaseView
    {
        public CaseView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CaseProperty = DependencyProperty.Register("Case", typeof(AbstractCase), typeof(CaseView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(EnumCaseOrientation), typeof(CaseView));

        public AbstractCase Case
        {
            get => (AbstractCase) GetValue(CaseProperty);
            set => SetValue(CaseProperty, value);
        }

        public EnumCaseOrientation Orientation
        {
            get => (EnumCaseOrientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        private void SelectedCase(MainViewModel _mainViewModel, AbstractCase _case)
        {
            if (_mainViewModel.SelectedCase == _case)
            {
                _mainViewModel.SelectedCase = null;
                return;
            }
            _mainViewModel.SelectedCase = _case;
        }
        
        private void Case_OnMouseLeftButtonUp(object _sender, MouseButtonEventArgs _e)
        {
            if (!(_sender is CaseView caseView)) return;
            if (!(caseView.Case is AbstractCase ccase)) return;
            if (!(caseView.DataContext is MainViewModel mainViewModel)) return;

            SelectedCase(mainViewModel, ccase);
        }

        private void ContextMenu_OnOpened(object _sender, RoutedEventArgs _e)
        {
            if (!(_sender is ContextMenu contextMenu)) return;
            if (!(contextMenu.PlacementTarget is CaseView caseView)) return;
            if (!(caseView.Case is AbstractCase ccase)) return;
            if (!(caseView.DataContext is MainViewModel mainViewModel)) return;

            SelectedCase(mainViewModel, ccase);
        }
    }
}
