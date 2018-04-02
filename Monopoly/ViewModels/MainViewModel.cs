using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monopoly.Interfaces;

namespace Monopoly.ViewModels
{
    public class MainViewModel : IViewModel
    {

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
