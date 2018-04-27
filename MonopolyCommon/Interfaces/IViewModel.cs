using System;
using System.ComponentModel;

namespace MonopolyCommon.Interfaces
{
    public interface IViewModel : IDisposable, INotifyPropertyChanged
    {
        IModel Model { get; set; }
    }
}
