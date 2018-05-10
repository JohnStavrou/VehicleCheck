using System;
using Windows.UI.Xaml.Data;

namespace VehicleCheck.Converters
{
    public class DateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (DateTimeOffset.Compare((DateTimeOffset)value, DateTimeOffset.Now) < 0)
                return "../Assets/x.png";
            if (DateTimeOffset.Compare((DateTimeOffset)value, DateTimeOffset.Now.AddMonths(1)) < 0)
                return "../Assets/warnwhite.png";
            if (DateTimeOffset.Compare((DateTimeOffset)value, DateTimeOffset.Now.AddMonths(2)) < 0)
                return null;
            if (DateTimeOffset.Compare((DateTimeOffset) value, DateTimeOffset.Now.AddMonths(3)) < 0)
                return null;
            return "../Assets/ok.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}