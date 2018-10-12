using System;
using GC.ProcessPayment.Api.Common;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public class BankingSystem : Engine, IBankingSystem
    {
        private readonly ICheapPaymentGateway _cheapGateway;
        private readonly IExpensivePaymentGateway _expensiveGateway;
        private readonly IPremiumPaymentGateway _premiumGateway;

        public BankingSystem(ICheapPaymentGateway cheapGateway,
                       IExpensivePaymentGateway expensiveGateway,
                       IPremiumPaymentGateway premiumGateway
                      ){
            _cheapGateway = cheapGateway;
            _expensiveGateway = expensiveGateway;
            _premiumGateway = premiumGateway;

            _cheapGateway.SetNext(_expensiveGateway);
            _expensiveGateway.SetNext(_premiumGateway);

        }

        public override bool Process(Payment payment)
        {
            return _cheapGateway.Process(payment);
        }
    }
}
