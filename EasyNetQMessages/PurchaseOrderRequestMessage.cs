namespace EasyNetQMessages
{
    public class PurchaseOrderRequestMessage
    {
        public string PoNumber { get; set; }
        public string CompanyName { get; set; }
        public int PaymentDayTerms { get; set; }
        public decimal Amount { get; set; }
    }
}