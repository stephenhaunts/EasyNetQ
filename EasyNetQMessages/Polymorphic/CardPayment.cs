namespace EasyNetQMessages.Polymorphic
{
    public class CardPayment : IPayment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }

        // Interface implementation
        public double Amount { get; set; }
    }
}
