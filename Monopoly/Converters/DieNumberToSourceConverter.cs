﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Monopoly.Converters
{
    public class DieNumberToSourceConverter : IValueConverter
    {
        public object Convert(object _value, Type _targetType, object _parameter, CultureInfo _culture)
        {
            if (_value == null) return null;
            var value = (int) _value;

            return $"../Images/dice{value}.png";
        }

        public object ConvertBack(object _value, Type _targetType, object _parameter, CultureInfo _culture)
        {
            throw new NotImplementedException();
        }
    }
}
