﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VehicleCheck.Converters
{
    public class InvBoolToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool) value)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}