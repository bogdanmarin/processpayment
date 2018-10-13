using System;
namespace GC.ProcessPayment.Api.DataAnnotation
{
    internal static class ErrorMessages
    {
        public static string INVALID_EXPIRATION_DATE = "Expiration date is required and should not be in the past.";
        public static string INVALID_SECURITY_CODE = "Invalid security code.";
        public static string INVALID_AMOUNT = "Amount is required and it must be a positive number";
    }
}
