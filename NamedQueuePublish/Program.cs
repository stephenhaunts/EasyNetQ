using System;
using EasyNetQ;
using EasyNetQMessages;

namespace NamedQueuePublish
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment1 = new CardPaymentNamedQueue
            {
                CardNumber = "1234123412341234",
                CardHolderName = "Mr F Bloggs",
                ExpiryDate = "12/12",
                Amount = 99.00m
            };

            var payment2 = new CardPaymentNamedQueue
            {
                CardNumber = "3456345634563456",
                CardHolderName = "Mr S Claws",
                ExpiryDate = "03/11",
                Amount = 15.00m
            };

            var payment3 = new CardPaymentNamedQueue
            {
                CardNumber = "6789678967896789",
                CardHolderName = "Mrs E Curry",
                ExpiryDate = "01/03",
                Amount = 1250.24m
            };

            var payment4 = new CardPaymentNamedQueue
            {
                CardNumber = "9991999299939994",
                CardHolderName = "Mrs D Parton",
                ExpiryDate = "04/07",
                Amount = 34.87m
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Publish(payment1);
                bus.Publish(payment2);
                bus.Publish(payment3);
                bus.Publish(payment4);
            }
        }
    }
}
