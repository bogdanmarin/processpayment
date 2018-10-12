using System;
using GC.ProcessPayment.Api.Entities;
using GC.ProcessPayment.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GC.ProcessPayment.Tests
{
    [TestClass]
    public class PremiumPaymentGatewayTests
    {
        readonly PremiumPaymentGateway _gateway = new PremiumPaymentGateway();
        [TestMethod]
        public void ShouldNotProcessNull()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(null);
            Assert.IsFalse(result, "Gateway should not process null payment");
        }

        [TestMethod]
        public void ShouldProcessAmountGreaterThen20()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(new Payment()
            {
                Amount = 21
            });

            Assert.IsTrue(result, "Gateway should process payment with amount greater than 20");
        }

        [TestMethod]
        public void ShouldProcessAmountGraterThan500()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(new Payment()
            {
                Amount = 501
            });

            Assert.IsTrue(result, "Gateway should process payment with amount grater than 500");
        }

    }
}
