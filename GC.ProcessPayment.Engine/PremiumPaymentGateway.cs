﻿using System;
using System.Net;
using GC.ProcessPayment.Api.Entities;

namespace GC.ProcessPayment.Engine
{
    public class PremiumPaymentGateway: Engine, IPremiumPaymentGateway
    {
        public PremiumPaymentGateway()
        {
        }

        public override bool Process(Payment payment)
        {
            return Retry.Execute(() =>
            {
                //simulate error
                Random rnd = new Random();
                var rndNumber = rnd.Next(1, 10);
                if (rndNumber != 3)
                    throw new WebException("Cannot connect to host");

                    return true;

            }, new TimeSpan(0, 0, 2), 3, true);
        }
    }
}
