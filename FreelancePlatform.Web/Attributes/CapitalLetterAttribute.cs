using System.ComponentModel.DataAnnotations;

namespace FreelancePlatform.Web.Attributes
{
    public class CapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string strValue = value.ToString();
                if (!string.IsNullOrEmpty(strValue) && char.IsLower(strValue[0]))
                {
                    // Повертаємо помилку, якщо перша літера маленька
                    return new ValidationResult(ErrorMessage ?? "Текст повинен починатися з великої літери.");
                }
            }
            return ValidationResult.Success;
        }
    }
}