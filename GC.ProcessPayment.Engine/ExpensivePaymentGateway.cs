using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public class ExpensivePaymentGateway: Engine, IExpensivePaymentGateway
    {
        public ExpensivePaymentGateway()
        {
        }

        public override bool Process(Payment payment)
        {
            if (payment.Amount > 500)
            {
                return _next != null && _next.Process(payment);
            }

            return true; //success
        }
    }
}
