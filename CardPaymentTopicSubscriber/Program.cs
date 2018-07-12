using System;
using EasyNetQ;
using EasyNetQMessages;

namespace CardPaymentTopicSubscriber
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<CardPaymentRequestMessage>("payments", HandleCardPaymentMessage, x => x.WithTopic("payment.cardpayment"));

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
    }
}
