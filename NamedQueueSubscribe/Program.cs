using System;
using EasyNetQ;
using EasyNetQMessages;

namespace NamedQueueSubscribe
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<CardPaymentNamesQueue>(string.Empty, HandleCardPaymentMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleCardPaymentMessage(CardPaymentNamesQueue paymentMessage)
        {
            Console.WriteLine("Processing Payment = <" +
                              paymentMessage.CardNumber + ", " +
                              paymentMessage.CardHolderName + ", " +
                              paymentMessage.ExpiryDate + ", " +
                              paymentMessage.Amount + ">");
        }
    }
}
