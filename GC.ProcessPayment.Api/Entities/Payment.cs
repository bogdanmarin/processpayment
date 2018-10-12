using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GC.ProcessPayment.Api.DataAnnotation;

namespace GC.ProcessPayment.Api.Entities
{
    public class Payment
    {
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        [ExpirationDate]
        public DateTime ExpirationDate { get; set; }

        [SecurityCode]
        public string SecurityCode { get; set; }

        [Range(0.0, Double.PositiveInfinity)]
        public decimal Amount { get; set; }
    }
}
