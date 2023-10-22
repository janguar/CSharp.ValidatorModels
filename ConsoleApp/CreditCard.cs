 namespace ConsoleApp
{
    public class CreditCard
    {
        public string CardType { get; set; }
        public string NameOnCard { get; set; }
        [CreditCard()]
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string BillingPostalCode { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
