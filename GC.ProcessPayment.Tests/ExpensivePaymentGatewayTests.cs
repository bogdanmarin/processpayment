using System;
using GC.ProcessPayment.Api.Entities;
using GC.ProcessPayment.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GC.ProcessPayment.Tests
{
    [TestClass]
    public class ExpensivePaymentGatewayTests
    {
        readonly ExpensivePaymentGateway _gateway = new ExpensivePaymentGateway();

        [TestMethod]
        public void ShouldNotProcessNull()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(null);
            Assert.IsFalse(result, "Gateway should not process null payment");
        }

        [TestMethod]
        public void ShouldNotProcessAmountGreaterThen500()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(new Payment()
            {
                Amount = 501
            });

            Assert.IsFalse(result, "Gateway should not process payment with amount greater than 501");
        }

        [TestMethod]
        public void ShouldProcessAmountLessAndEqualThen500()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(new Payment()
            {
                Amount = 500
            });

            Assert.IsTrue(result, "Gateway should process payment with amount less and equal than 500");
        }


        [TestMethod]
        public void CanLinkWithPremium()
        {
            _gateway.SetNext(new PremiumPaymentGateway());

            bool result = _gateway.Process(new Payment()
            {
                Amount = 501
            });


            Assert.IsTrue(result, "Payment should be processed by the next PremiumPaymentGateway");
        }
    }
}
