using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BouncyCastles.WebUI.Infrastructure
{
    public class RegexFromConfigValidatorAttribute : ValidationAttribute
    {
        public string OtherProperty { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            string regexFromDb = ConfigurationManager.AppSettings.Get("RegularExpressionDutch");

            Regex r = new Regex(regexFromDb);

            if (value is string && r.IsMatch(value as string))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ConfigurationManager.AppSettings.Get("RegularExpressionDutchMessage"));
            }
        }
    }
}
