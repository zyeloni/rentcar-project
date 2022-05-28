using System;
using System.Globalization;
using System.Windows.Data;

namespace RentCarDesktopApp.Conventers;

[ValueConversion(typeof(DateTime), typeof(String))]
public class OnlyYearConventer : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime dateTime = (DateTime)value;

        return dateTime.Year.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return new DateTime(Int32.Parse(value as string), 1, 1);
    }
}