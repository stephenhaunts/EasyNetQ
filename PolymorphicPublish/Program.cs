using System;
using EasyNetQ;
using EasyNetQMessages.Polymorphic;

namespace PolymorphicPublish
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
                Console.WriteLine("Publishing messages with publish and subscribe.");
                Console.WriteLine("  -- Polymorphic message.");
                Console.WriteLine();

                bus.Publish<IPayment>(cardPayment1);
                bus.Publish<IPayment>(purchaseOrder1);
                bus.Publish<IPayment>(cardPayment2);  
                bus.Publish<IPayment>(purchaseOrder2);
            }
        }
    }
}
