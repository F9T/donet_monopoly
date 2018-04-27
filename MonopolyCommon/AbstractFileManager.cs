using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonopolyCommon
{
    public abstract class AbstractFileManager : INotifyPropertyChanged
    {
        private bool isCreated, isSaved;

        protected AbstractFileManager()
        {
            IsCreated = false;
            IsSaved = false;
        }

        protected abstract void New();
        protected abstract void Close();
        protected abstract void Load();
        protected abstract void Save();
        protected abstract void SaveAs();


        public bool IsCreated
        {
            get => isCreated;
            set
            {
                isCreated = value;
                OnPropertyChanged(nameof(IsCreated));
            }
        }

        public bool IsSaved
        {
            get => isSaved;
            set
            {
                isSaved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}