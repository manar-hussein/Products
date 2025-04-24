namespace Products.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Product> products { get; set; } = new List<Product>();
    }
}
