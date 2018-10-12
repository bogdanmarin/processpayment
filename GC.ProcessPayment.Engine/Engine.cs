using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public abstract class Engine : IEngine
    {
        protected IEngine _next = null;

        public abstract bool Process(Payment payment);
       
        public void SetNext(IEngine next)
        {
            _next = next;
        }
    }
}
