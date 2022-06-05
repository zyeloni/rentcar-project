using System;
using System.Globalization;
using System.Windows.Data;

namespace RentCarDesktopApp.Conventers;

[ValueConversion(typeof(DateTime), typeof(String))]
public class DateConventer : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime dateTime = (DateTime)value;

        return dateTime.ToString("d"); 
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}