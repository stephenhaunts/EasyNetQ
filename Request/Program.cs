using System;
using EasyNetQ;
using EasyNetQMessages;

namespace Request
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment = new CardPaymentRequestMessage
            {
                CardNumber = "1234123412341234",
                CardHolderName = "Mr F Bloggs",
                ExpiryDate = "12/12",
                Amount = 99.00m
            };

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Preparing to send message to RabbitMQ");

                var response = bus.Request<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);
                Console.WriteLine(response.AuthCode);

                Console.WriteLine("Response received.");
            }
        }
    }
}
