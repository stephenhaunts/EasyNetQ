namespace EasyNetQMessages.Polymorphic
{
    public class CardPayment : IPayment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }

        // Interface implementation
        public decimal Amount { get; set; }
    }
}
