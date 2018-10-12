using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Api.Common
{
    public interface IBankingSystem
    {
        bool Process(Payment payment);
    }
}
