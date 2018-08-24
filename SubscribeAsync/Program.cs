using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQMessages;

namespace SubscribeAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.SubscribeAsync<CardPaymentRequestMessage>("cardPayment", message => Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Payment = <" + 
                                      message.CardNumber + ", " + 
                                      message.CardHolderName + ", " + 
                                      message.ExpiryDate + ", " + 
                                      message.Amount + ">");
                }).ContinueWith(task =>
                {
                    if (task.IsCompleted && !task.IsFaulted)
                    {
                        Console.WriteLine("Finished processing all messages");
                    }
                    else
                    {
                        // Dont catch this, it is caught further up the heirarchy and results in being sent to the default error queue
                        // on the broker
                        throw new EasyNetQException("Message processing exception - look in the default error queue (broker)");
                    }
                }));

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }
    }
}
