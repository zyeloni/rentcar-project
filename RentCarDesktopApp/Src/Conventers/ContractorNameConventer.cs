using System;
using System.Globalization;
using System.Windows.Data;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Conventers;

[ValueConversion(typeof(Contractor), typeof(String))]
public class ContractorNameConventer : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Contractor contractor = (value as Contractor);

        return String.Format("{0} {1}", contractor.FirstName, contractor.SurName);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}