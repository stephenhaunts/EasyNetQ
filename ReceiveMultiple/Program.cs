using System;
using EasyNetQ;
using EasyNetQMessages;

namespace ReceiveMultiple
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {             
                bus.Receive("my.paymentsqueue", x => x
                            .Add<CardPaymentRequestMessage>(message => HandleCardPaymentMessage(message))
                            .Add<PurchaseOrderRequestMessage>(message => HandlePurchaseOrderPaymentMessage(message)));

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleCardPaymentMessage(CardPaymentRequestMessage paymentMessage)
        {
            Console.WriteLine("Processing Payment = <" +
                              paymentMessage.CardNumber + ", " +
                              paymentMessage.CardHolderName + ", " +
                              paymentMessage.ExpiryDate + ", " +
                              paymentMessage.Amount + ">");
        }

        static void HandlePurchaseOrderPaymentMessage(PurchaseOrderRequestMessage purchaseOrder)
        {
            Console.WriteLine("Processing Purchase Order = <" +
                               purchaseOrder.CompanyName + ", " +
                               purchaseOrder.PoNumber + ", " +
                               purchaseOrder.PaymentDayTerms + ", " +
                               purchaseOrder.Amount + ">");
        }
    }
}
