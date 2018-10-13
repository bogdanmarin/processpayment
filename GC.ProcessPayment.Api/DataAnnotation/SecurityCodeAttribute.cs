﻿using System;
using System.ComponentModel.DataAnnotations;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Api.DataAnnotation
{
    internal class SecurityCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            bool isValueString = value is string;

            if (!isValueString)
                return new ValidationResult(ErrorMessages.INVALID_SECURITY_CODE);

            string securityCode = (string)value;

            if (!String.IsNullOrEmpty(securityCode) && securityCode.Length != 3)
                return new ValidationResult(ErrorMessages.INVALID_SECURITY_CODE);

            return ValidationResult.Success;
        }
    }
}
