using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Color = Windows.UI.Color;

namespace VehicleCheck.Converters
{
    public class DateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (DateTimeOffset.Compare((DateTimeOffset) value, DateTimeOffset.Now) < 0)
                return ColorConverter("D32F2F");
            if (DateTimeOffset.Compare((DateTimeOffset)value, DateTimeOffset.Now.AddMonths(1)) < 0)
                return ColorConverter("F57C00");
            if (DateTimeOffset.Compare((DateTimeOffset)value, DateTimeOffset.Now.AddMonths(2)) < 0)
                return ColorConverter("FDD835");
            if (DateTimeOffset.Compare((DateTimeOffset)value, DateTimeOffset.Now.AddMonths(3)) < 0)
                return ColorConverter("C0CA33");
            return ColorConverter("43A047");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public SolidColorBrush ColorConverter(string hex)
        {
            var r = (byte) System.Convert.ToUInt32(hex.Substring(0, 2), 16);
            var g = (byte) System.Convert.ToUInt32(hex.Substring(2, 2), 16);
            var b = (byte) System.Convert.ToUInt32(hex.Substring(4, 2), 16);

            return new SolidColorBrush(Color.FromArgb(255, r, g, b));
        }
    }
}