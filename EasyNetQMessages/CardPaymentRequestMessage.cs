namespace EasyNetQMessages
{
    public class CardPaymentRequestMessage
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public decimal Amount { get; set; }
    }
}
