using System;
using EasyNetQ;
using EasyNetQMessages;

namespace AccountsDeptTopicSubscriber
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<object>("payments", HandlePaymentMessage, x => x.WithTopic("payment.*"));
               // bus.Subscribe<PurchaseOrderRequestMessage>("payments", HandlePaymentMessage, x => x.WithTopic("payment.*"));


                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandlePaymentMessage(object paymentMessage)
        {
            if (paymentMessage is CardPaymentRequestMessage)
            {
                var payment = paymentMessage as CardPaymentRequestMessage;
                Console.WriteLine("Processing Payment = <" +
                                  payment.CardNumber + ", " +
                                  payment.CardHolderName + ", " +
                                  payment.ExpiryDate + ", " +
                                  payment.Amount + ">");
            }
            else if (paymentMessage is PurchaseOrderRequestMessage)
            {
                var payment = paymentMessage as PurchaseOrderRequestMessage;
                Console.WriteLine("Processing Purchase Order = <" +
                                  payment.CompanyName + ", " +
                                  payment.PoNumber + ", " +
                                  payment.PaymentDayTerms + ", " +
                                  payment.Amount + ">"); 
            }
        }
            
    }
}
