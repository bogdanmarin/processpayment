using System;
using System.ComponentModel.DataAnnotations;
using GC.ProcessPayment.Api.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GC.ProcessPayment.Api.DataAnnotation
{
    internal class ExpirationDateAttribute : ValidationAttribute
    {
        public ExpirationDateAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValueDate = value is DateTime;

            if (!isValueDate)
                return new ValidationResult(ErrorMessages.INVALID_EXPIRATION_DATE);

            DateTime expirationDate = (DateTime)value;

            if (expirationDate < DateTime.Today)
                return new ValidationResult(ErrorMessages.INVALID_EXPIRATION_DATE);

            return ValidationResult.Success;
        }
    }
}
