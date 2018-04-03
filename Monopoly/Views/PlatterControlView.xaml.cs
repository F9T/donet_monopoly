namespace Monopoly.Views
{
    /// <summary>
    /// Logique d'interaction pour PlatterControlView.xaml
    /// </summary>
    public partial class PlatterControlView
    {
        public PlatterControlView()
        {
            InitializeComponent();
         /*   DataContext = this;
            foreach (var mcase in Cases)
            {
                var view = new CaseView {Case = mcase};
                Grid.SetRow(view, mcase.Position.X);
                Grid.SetColumn(view, mcase.Position.Y);
                PlatterGrid.Children.Add(view);
            }*/
        }
    }
}
