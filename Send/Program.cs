﻿using System;
using EasyNetQ;
using EasyNetQMessages;

namespace Send
{
    class Program
    {
        public static void Main(string[] args)
        {
            var payment1 = new CardPaymentRequestMessage
            {
                CardNumber = "1234123412341234",
                CardHolderName = "Mr F Bloggs",
                ExpiryDate = "12/12",
                Amount = 99.00m
            };

            var payment2 = new CardPaymentRequestMessage
            {
                CardNumber = "3456345634563456",
                CardHolderName = "Mr S Claws",
                ExpiryDate = "03/11",
                Amount = 15.00m
            };

            var payment3 = new CardPaymentRequestMessage
            {
                CardNumber = "6789678967896789",
                CardHolderName = "Mrs E Curry",
                ExpiryDate = "01/03",
                Amount = 1250.24m
            };

            var payment4 = new CardPaymentRequestMessage
            {
                CardNumber = "9991999299939994",
                CardHolderName = "Mrs D Parton",
                ExpiryDate = "04/07",
                Amount = 34.87m
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Send("my.paymentsqueue", payment1);
                bus.Send("my.paymentsqueue", payment2);
                bus.Send("my.paymentsqueue", payment3);
                bus.Send("my.paymentsqueue", payment4);
            }
          
        }
    }
}
