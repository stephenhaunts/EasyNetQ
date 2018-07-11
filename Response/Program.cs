using System;
using EasyNetQ;
using EasyNetQMessages;

namespace Response
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Respond<CardPaymentRequestMessage, CardPaymentResponseMessage>(Responder);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static CardPaymentResponseMessage Responder(CardPaymentRequestMessage request)
        {
            return new CardPaymentResponseMessage { AuthCode = "1234" };
        }
    }
}
