using GC.ProcessPayment.Api.Entities;
using GC.ProcessPayment.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GC.ProcessPayment.Tests
{
    [TestClass]
    public class CheapPaymentGatewayTests
    {
        readonly CheapPaymentGateway _gateway = new CheapPaymentGateway();

        [TestMethod]
        public void ShouldNotProcessNull()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(null);
            Assert.IsFalse(result, "Gateway should not process null payment");
        }

        [TestMethod]
        public void ShouldNotProcessAmountGreaterThen20()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(new Payment()
            {
                Amount = 21
            });

            Assert.IsFalse(result, "Gateway should not process payment with amount greater than 20");
        }

        [TestMethod]
        public void ShouldProcessAmountLessAndEqualThen20()
        {
            _gateway.SetNext(null);

            bool result = _gateway.Process(new Payment()
            {
                Amount = 20
            });

            Assert.IsTrue(result, "Gateway should process payment with amount less and equal than 20");
        }

        [TestMethod]
        public void CanLinkWithExpensive()
        {
            _gateway.SetNext(new ExpensivePaymentGateway());

            bool result = _gateway.Process(new Payment()
            {
                Amount = 21
            });


            Assert.IsTrue(result, "Payment should be processed by the next ExpensivePaymentGateway");
        }

        [TestMethod]
        public void CanLinkWithPremium()
        {
            _gateway.SetNext(new PremiumPaymentGateway());

            bool result = _gateway.Process(new Payment()
            {
                Amount = 21
            });


            Assert.IsTrue(result, "Payment should be processed by the next PremiumPaymentGateway");
        }

    }
}
