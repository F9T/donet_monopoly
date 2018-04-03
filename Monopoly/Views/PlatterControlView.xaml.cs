using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Monopoly.Models;
using Monopoly.Models.Cases;

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
