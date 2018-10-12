using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public class CheapPaymentGateway: Engine, ICheapPaymentGateway
    {
        public CheapPaymentGateway()
        {
        }

        public override bool Process(Payment payment)
        {
            if (payment.Amount > 20)
            {
                return _next != null && _next.Process(payment);
            }

            return true; //success
        }
    }
}
