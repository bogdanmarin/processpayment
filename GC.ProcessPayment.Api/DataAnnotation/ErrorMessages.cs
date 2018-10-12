using System;
namespace GC.ProcessPayment.Api.DataAnnotation
{
    internal static class ErrorMessages
    {
        public static string INVALID_EXPIRATION_DATE = "Expiration date should be in the past.";
        public static string INVALID_SECURITY_CODE = "Invalid security code.";
    }
}
