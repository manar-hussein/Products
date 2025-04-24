namespace Products.Models
{
    public class BankCard
    {
        public string CardNumber { get; set; } = null!;
        public DateOnly ExpiryDate { get; set; }
        public int CVV { get; set; }
        public string NameonCard { get; set; } = null!;
    }
}
