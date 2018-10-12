using System;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public interface IEngine
    {
        bool Process(Payment payment);
        void SetNext(IEngine next);
    }
}
