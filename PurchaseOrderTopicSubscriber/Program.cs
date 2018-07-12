using System;
using EasyNetQ;
using EasyNetQMessages;

namespace PurchaseOrderTopicSubscriber
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<PurchaseOrderRequestMessage>("payments", HandlePurchaseOrder, x => x.WithTopic("payment.purchaseorder"));

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandlePurchaseOrder(PurchaseOrderRequestMessage purchaseOrder)
        {
            Console.WriteLine("Processing Purchase Order = <" +
                               purchaseOrder.CompanyName + ", " +
                               purchaseOrder.PoNumber + ", " +
                               purchaseOrder.PaymentDayTerms + ", " +
                               purchaseOrder.Amount + ">");
        }
    }
}
