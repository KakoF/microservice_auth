using System.ComponentModel.DataAnnotations;

namespace apiAuth.utils.validation
{
  public class CustomNameAttribute : ValidationAttribute
  {
    private readonly string _startsWith;

    public CustomNameAttribute(string startsWith)
    {
      _startsWith = startsWith;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value is string valueString && !valueString.StartsWith(_startsWith))
        return new ValidationResult($"{validationContext.MemberName} não começa com {_startsWith}");

      return ValidationResult.Success;

    }
  }
}