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

        [ExpirationDate]
        public DateTime? ExpirationDate { get; set; }

        [SecurityCode]
        public string SecurityCode { get; set; }

        [Amount]
        public decimal? Amount { get; set; }
    }
}
