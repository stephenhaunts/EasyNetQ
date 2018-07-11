using System;
using EasyNetQ;
using EasyNetQMessages.Polymorphic;

namespace PolymorphicSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            { 
                bus.Subscribe<IPayment>("payments", @interface =>
                {
                    var cardPayment = @interface as CardPayment;
                    var purchaseOrder = @interface as PurchaseOrder;

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
                    else
                    {
                        Console.Out.WriteLine("Invalid message. Needs to be a Card Payment or Purchase Order.");
                    }
                });

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }
    }
}
