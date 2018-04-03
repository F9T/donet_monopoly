using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monopoly.Interfaces;

namespace Monopoly.ViewModels
{
    public class MainViewModel : IViewModel
    {
        public MainViewModel()
        {
            PlatterViewModel = new PlatterViewModel();
            PlatterViewModel.Deserialize(@"D:\HE-ARC\DotNet\Projets\monopoly\dotnet_monopoly\Monopoly\PlatterExample\example.xml");
        }

        public PlatterViewModel PlatterViewModel { get; set; }

        public void Dispose()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
