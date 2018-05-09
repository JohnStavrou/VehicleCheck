using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace VehicleCheck.Converters
{
    public class DateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (DateTimeOffset.Compare((DateTimeOffset) value, DateTimeOffset.Now) > 0)
                return new SolidColorBrush(Colors.Red);
            if (DateTimeOffset.Compare(((DateTimeOffset) value).AddMonths(1), DateTimeOffset.Now) > 0)
                return new SolidColorBrush(Colors.Orange);
            return new SolidColorBrush(Colors.Green);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}