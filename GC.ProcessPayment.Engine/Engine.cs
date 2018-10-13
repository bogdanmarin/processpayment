using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public abstract class Engine : IEngine
    {
        protected IEngine _next = null;

        public abstract bool Process(Payment payment);

        protected bool Process(Payment payment, int trashhold){
            if (payment == null)
                return false;

            if (payment.Amount < 0)
                return false;

            if (payment.Amount > trashhold)
            {
                return _next != null && _next.Process(payment);
            }

            return true; //success
        }

        public void SetNext(IEngine next)
        {
            _next = next;
        }
    }
}
