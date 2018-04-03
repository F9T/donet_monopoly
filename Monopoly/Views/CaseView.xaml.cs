using System.Windows;
using Monopoly.Models.Cases;

namespace Monopoly.Views
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

        public AbstractCase Case
        {
            get => (AbstractCase) GetValue(CaseProperty);
            set => SetValue(CaseProperty, value);
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(EnumCaseOrientation), typeof(CaseView));

        public EnumCaseOrientation Orientation
        {
            get => (EnumCaseOrientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
    }
}
