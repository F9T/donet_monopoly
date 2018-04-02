using System.Windows;
using Monopoly.Interfaces;
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
            DataContext = this;
        }

        public AbstractCase Case { get; set; }
    }
}
