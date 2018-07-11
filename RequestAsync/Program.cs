using System;
using EasyNetQ;
using EasyNetQMessages;

namespace RequestAsync
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

                var task = bus.RequestAsync<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);

                task.ContinueWith(response => {
                    Console.WriteLine("Got response: '{0}'", response.Result.AuthCode);
                });

                Console.ReadLine();
            }
        }
    }
}
