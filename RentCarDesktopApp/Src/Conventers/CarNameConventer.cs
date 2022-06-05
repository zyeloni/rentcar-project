using System;
using System.Globalization;
using System.Windows.Data;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Conventers;

[ValueConversion(typeof(Car), typeof(String))]
public class CarNameConventer : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Car car = (value as Car);

        return String.Format("{0} {1} - {2}", car.Brand, car.Model, car.Year.Year);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}