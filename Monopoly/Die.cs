using System;

namespace Monopoly
{
    public class Die
    {
        private readonly int minimum, maximum;
        private readonly Random random;

        public Die(int _minimum, int _maximum)
        {
            random = new Random(DateTime.Now.Millisecond);
            minimum = _minimum;
            maximum = _maximum;
        }

        public int Roll()
        {
            return random.Next(minimum, maximum + 1);
        }
    }
}
