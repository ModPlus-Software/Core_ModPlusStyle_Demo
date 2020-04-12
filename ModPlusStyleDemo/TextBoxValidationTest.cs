namespace ModPlusStyleDemo
{
    using System.Globalization;
    using System.Windows.Controls;

    public class TextBoxValidationTest : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value.ToString() == "1")
                return ValidationResult.ValidResult;
            else return new ValidationResult(false, "Ooooops =)");
        }
    }
}
