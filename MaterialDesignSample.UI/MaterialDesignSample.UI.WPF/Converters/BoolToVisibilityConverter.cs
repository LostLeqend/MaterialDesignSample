using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MaterialDesignSample.UI.WPF.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool IsInverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return null;

            return (bool)value ^ IsInverse ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
