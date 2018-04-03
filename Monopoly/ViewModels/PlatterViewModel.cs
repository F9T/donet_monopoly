using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Monopoly.Interfaces;
using Monopoly.Models;

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
            var serializer = new XmlSerializer(typeof(Platter));
            using (var sw = new StreamWriter(_path))
            {
                serializer.Serialize(sw, Platter);
            }
        }

        public void Deserialize(string _path)
        {
            var serializer = new XmlSerializer(typeof(Platter));
            using (var sr = new StreamReader(_path))
            {
                Platter = (Platter) serializer.Deserialize(sr);
            }
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
