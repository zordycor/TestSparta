using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TestSparta.Converter
{
    public class PriceToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double input = double.Parse((string)value);
            if (input > 10) // HOW TO CHANGE "10" BY CELL FIRST VALUE?
            {
                return Brushes.Green;

            }
            else if (input < 10)
            {
                return Brushes.Red;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
