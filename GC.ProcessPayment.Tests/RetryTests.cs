using System;
using GC.ProcessPayment.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GC.ProcessPayment.Tests
{
    [TestClass]
    public class RetryTests
    {
        [TestMethod]
        public void ShouldRetryTwice(){
            int retry = 0;

            bool result = Retry.Execute(() =>
            {
                if (retry < 2)
                {
                    retry++;
                    throw new ArgumentException("Cannot connect to host");

                }

                return true;

            }, new TimeSpan(0, 0, 1), 3, true, true);

            Assert.IsTrue(result, "Should return true after 2 failures");
            Assert.AreEqual(retry, 2);
        }
    }
}
