using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public class ExpensivePaymentGateway: Engine, IExpensivePaymentGateway
    {
        public override bool Process(Payment payment)
        {
            return base.Process(payment, 500);
        }
    }
}
