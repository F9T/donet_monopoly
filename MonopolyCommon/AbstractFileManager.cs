using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonopolyCommon
{
    /// <summary>
    /// Abstract class to centralize file managing interface
    /// </summary>
    public abstract class AbstractFileManager : INotifyPropertyChanged
    {
        // states
        private bool isCreated, isSaved;

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AbstractFileManager()
        {
            IsCreated = false;
            IsSaved = false;
        }

        // ------- Global commands -------

        protected abstract void New();
        protected abstract bool Close();
        protected abstract void Load();
        protected abstract void Save();
        protected abstract void SaveAs();

        // ------------------------------

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