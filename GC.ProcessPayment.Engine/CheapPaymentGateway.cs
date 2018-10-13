using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public class CheapPaymentGateway: Engine, ICheapPaymentGateway
    {
        public override bool Process(Payment payment)
        {
            return base.Process(payment, 20);
        }
    }
}
