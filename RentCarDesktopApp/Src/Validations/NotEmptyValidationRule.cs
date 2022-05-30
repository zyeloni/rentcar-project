using System;
using System.Globalization;
using System.Windows.Controls;

namespace RentCarDesktopApp.Validations;

public class NotEmptyValidationRule : ValidationRule {
    
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value.ToString().Equals(String.Empty) || value.ToString().Trim().Equals(String.Empty))
            return new ValidationResult(false, "Te pole nie może być puste");

        return ValidationResult.ValidResult;
    }
    
}
