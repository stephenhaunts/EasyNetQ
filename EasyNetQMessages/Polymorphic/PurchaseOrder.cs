namespace EasyNetQMessages.Polymorphic
{
    public class PurchaseOrder : IPayment
    {
        public string PoNumber { get; set; }
        public string CompanyName { get; set; }
        public int PaymentDayTerms { get; set; }

        // Interface implementation
        public decimal Amount { get; set; }
    }
}