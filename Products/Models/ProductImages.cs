namespace Products.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public Product? Product { get; set; }
    }
}
