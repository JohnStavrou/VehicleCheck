﻿using System;
using Windows.UI.Xaml.Data;

namespace VehicleCheck.Converters
{
    public class DateToFormattedDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset) value).ToString("dd/MMM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}