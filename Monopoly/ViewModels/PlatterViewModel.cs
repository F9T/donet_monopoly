using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monopoly.Interfaces;
using MonopolyCommon;

namespace Monopoly.ViewModels
{
    public class PlatterViewModel : IViewModel
    {
        public PlatterViewModel()
        {
            Platter = new Platter();
        }

        public Platter Platter { get; set; }


        public void Serialize(string _path)
        {
            PlatterSerializer.Serialize(Platter);
        }

        public void Deserialize(string _path)
        {
            Platter = PlatterSerializer.Deserialize(_path);
        }

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
