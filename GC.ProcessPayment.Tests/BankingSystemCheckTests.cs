using System;
using GC.ProcessPayment.Api.Entities;
using GC.ProcessPayment.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GC.ProcessPayment.Tests
{
    [TestClass]
    public class BankingSystemCheckTests
    {
        readonly BankingSystem _engine = new BankingSystem(
            new CheapPaymentGateway(),
            new ExpensivePaymentGateway(),
            new PremiumPaymentGateway()
        );

        [TestMethod]
        public void ShouldNotProcessNull()
        {
            bool result = _engine.Process(null);
            Assert.IsFalse(result, "System should not process null payment");
        }

        [TestMethod]
        public void ShouldProcessAmountGreaterThen20()
        {
            bool result = _engine.Process(new Payment()
            {
                Amount = 21
            });

            Assert.IsTrue(result, "System should process payment with amount greater than 20");
        }

        [TestMethod]
        public void ShouldProcessAmountLessAndEqualThen20()
        {
            bool result = _engine.Process(new Payment()
            {
                Amount = 20
            });

            Assert.IsTrue(result, "System should process payment with amount less and equal than 20");
        }

        [TestMethod]
        public void ShouldProcessAmountGraterThan500()
        {
            bool result = _engine.Process(new Payment()
            {
                Amount = 501
            });

            Assert.IsTrue(result, "System should process payment with amount grater than 500");
        }


        [TestMethod]
        public void ShouldNotProcessNegativeAmount()
        {
            bool result = _engine.Process(new Payment()
            {
                Amount = -501
            });

            Assert.IsFalse(result, "System should not process payment with negative amount");
        }

    }
}
