namespace ModPlusStyleDemo
{
    using System.Globalization;
    using System.Windows.Controls;

    public class TextBoxValidationTest : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value?.ToString() == "1"
                ? ValidationResult.ValidResult 
                : new ValidationResult(false, "Ooooops =)");
        }
    }
}
