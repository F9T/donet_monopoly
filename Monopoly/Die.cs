using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monopoly
{
    public class Die : INotifyPropertyChanged
    {
        private readonly int minimum, maximum;
        private readonly Random random;
        private int numberRoll;

        public Die(int _minimum, int _maximum)
        {
            random = new Random(Guid.NewGuid().GetHashCode());
            minimum = _minimum;
            maximum = _maximum;
            NumberRoll = 0;
        }

        public int NumberRoll
        {
            get => numberRoll;
            set
            {
                numberRoll = value;
                OnPropertyChanged(nameof(NumberRoll));
            }
        }

        public int Roll()
        {
            NumberRoll = random.Next(minimum, maximum + 1);
            return NumberRoll;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }
    }
}
