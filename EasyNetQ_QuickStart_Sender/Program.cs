using System;
using EasyNetQ;
using EasyNetQMessages;

namespace EasyNetQTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                using (var bus = RabbitHutch.CreateBus("host=localhost"))
                {
                    bus.Publish(new TextMessage
                    {
                        Text = i + ": Hello World from EasyNetQ"
                    });
                }
            }
        }
    }
}
