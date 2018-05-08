using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VehicleCheck.Converters
{
    public class ConnectedToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if ((bool) value)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}