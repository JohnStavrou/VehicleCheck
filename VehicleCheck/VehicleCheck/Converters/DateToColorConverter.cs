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
            if (value == null)
                return null;

            if (DateTime.Compare((DateTime) value, DateTime.Now) > 0)
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.Green);
            //todo orange ena mina prin
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}