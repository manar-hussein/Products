namespace Products.ViewModels.Product
{
    public class PurchaseProductViewModel
    {
        public ProductViewModel Product { get; set; } = null!;
        public BuyerDetails Buyer { get; set; } = null!;
    }
}
