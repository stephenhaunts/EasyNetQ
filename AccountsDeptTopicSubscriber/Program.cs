using System;
using EasyNetQ;
using EasyNetQMessages;
using EasyNetQMessages.Polymorphic;

namespace AccountsDeptTopicSubscriber
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("payments", Handler, x => x.WithTopic("payment.*"));//.WithTopic("payment.purchaseorder"));

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        public static void Handler(IPayment payment)
        {
            var cardPayment = payment as CardPayment;
            var purchaseOrder = payment as PurchaseOrder;

            if (cardPayment != null)
            {
                Console.WriteLine("Processing Card Payment = <" +
                                  cardPayment.CardNumber + ", " +
                                  cardPayment.CardHolderName + ", " +
                                  cardPayment.ExpiryDate + ", " +
                                  cardPayment.Amount + ">");
            }
            else if (purchaseOrder != null)
            {
                Console.WriteLine("Processing Purchase Order = <" +
                                  purchaseOrder.CompanyName + ", " +
                                  purchaseOrder.PoNumber + ", " +
                                  purchaseOrder.PaymentDayTerms + ", " +
                                  purchaseOrder.Amount + ">");
            }
        }
    }
}
