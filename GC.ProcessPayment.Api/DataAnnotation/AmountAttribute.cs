using System;
using System.ComponentModel.DataAnnotations;

namespace GC.ProcessPayment.Api.DataAnnotation
{
    public class AmountAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ErrorMessages.INVALID_AMOUNT);

            try
            {
                decimal amount = (decimal)value;

                if (amount <= 0)
                {
                    return new ValidationResult(ErrorMessages.INVALID_AMOUNT);
                }

            }catch(Exception)
            {
                return new ValidationResult(ErrorMessages.INVALID_AMOUNT);
            }

            return ValidationResult.Success;
        }
    }
}
