using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Monopoly.Models.Cases;

namespace Monopoly.Views
{
    /// <summary>
    /// Logique d'interaction pour PlatterControl.xaml
    /// </summary>
    public partial class PlatterControl : INotifyPropertyChanged
    {
        public PlatterControl()
        {
            InitializeComponent();
            DataContext = this;
            Cases = new ObservableCollection<AbstractCase>();
            int posX = 0, posY = 0;
            var orientation = EnumCaseOrientation.VerticalReverse;
            for (int i = 0; i < 40; i++)
            {
                if (i == 3 || i == 5 || i == 23 || i == 13)
                {
                    Cases.Add(new PropertyCase
                    {
                        Position = new Point(posX, posY),
                        Color = new SolidColorBrush(Colors.Blue),
                        PropertyName = "Super",
                        Price = 100,
                        Orientation = orientation
                    });
                }
                else
                {
                    Cases.Add(new StartCase
                    {
                        Position = new Point(posX, posY),
                        Orientation = orientation
                    });
                }
                if (posX % 10 == 0)
                {
                    posY++;
                    if (posY == 11)
                    {
                        posY = 0;
                        posX++;
                        orientation = EnumCaseOrientation.Horizontal;
                    }
                    if (posX == 10)
                    { 
                        orientation = EnumCaseOrientation.Vertical;
                    }
                }
                else
                {
                    if (posY == 0)
                    {
                        posY = 10;
                        orientation = EnumCaseOrientation.HorizontalReverse;
                    }
                    else if (posY == 10)
                    {
                        posY = 0;
                        posX++;
                        orientation = EnumCaseOrientation.Horizontal;
                    }
                }
            }
            foreach (var mcase in Cases)
            {
                var view = new CaseView {Case = mcase};
                Grid.SetRow(view, mcase.Position.X);
                Grid.SetColumn(view, mcase.Position.Y);
                PlatterGrid.Children.Add(view);
            }
        }

        public ObservableCollection<AbstractCase> Cases { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
