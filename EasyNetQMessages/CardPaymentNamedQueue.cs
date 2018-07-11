using EasyNetQ;

namespace EasyNetQMessages
{
    [Queue("CardPaymentQueue", ExchangeName = "CardPaymentExchange")]
    public class CardPaymentNamedQueue
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public decimal Amount { get; set; }
    }
}
