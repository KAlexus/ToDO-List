using System.Globalization;
using System.Windows.Controls;

namespace ToDO
{
    public class LengthValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value?.ToString().Length > 35
                ? new ValidationResult(false, "Field is too long.")
                : ValidationResult.ValidResult;
        }
    }
}
