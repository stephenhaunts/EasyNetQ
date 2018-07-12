﻿using System;
using EasyNetQ;
using EasyNetQMessages;
using EasyNetQMessages.Polymorphic;

namespace TopicPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardPayment1 = new CardPayment
            {
                Amount = 24.99m,
                CardHolderName = "Mr T Drump",
                CardNumber = "1234123412341234",
                ExpiryDate = "12/12"
            };

            var cardPayment2 = new CardPayment
            {
                Amount = 134.25m,
                CardHolderName = "Mrs C Hlinton",
                CardNumber = "1234123412341234",
                ExpiryDate = "12/12"
            };

            var purchaseOrder1 = new PurchaseOrder
            {
                Amount = 134.25m,
                CompanyName = "Wayne Enterprises",
                PaymentDayTerms = 30,
                PoNumber = "BM666"
            };

            var purchaseOrder2 = new PurchaseOrder
            {
                Amount = 99.00m,
                CompanyName = "HeadBook",
                PaymentDayTerms = 30,
                PoNumber = "HB123"
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Publish<IPayment>(cardPayment1, "payment.cardpayment");
                bus.Publish<IPayment>(purchaseOrder1, "payment.purchaseorder");
                bus.Publish<IPayment>(cardPayment2, "payment.cardpayment");
                bus.Publish<IPayment>(purchaseOrder2, "payment.purchaseorder");
            }
        }
    }
}