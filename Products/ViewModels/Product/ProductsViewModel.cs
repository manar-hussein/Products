namespace Products.ViewModels.Product
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string HeaderImage { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public bool IsBought { get; set; }
        public string Brand { get; set; } = null!;
        public int NumberOfExisitItems { get; set; }
        public int Quantity { get; set; }

    }
}
