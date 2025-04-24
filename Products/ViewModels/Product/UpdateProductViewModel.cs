using System.ComponentModel.DataAnnotations;

namespace Products.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "e.g. Iphone Pro Max")]
        public string ProductName { get; set; } = null!;
        [Display(Name = "e.g. Apple")]
        public string Brand { get; set; } = null!;
        [Display(Name = "e.g. 999")]
        public double Price { get; set; }
        [Display(Name = "Detailed Description of The Product")]
        public string Description { get; set; } = null!;

        [Display(Name = "e.g. 240")]
        public int Weight { get; set; }

        [Display(Name = "e.g. 160.8 x 78.1 x 7.65")]
        public string Dimensions { get; set; } = null!;

        [Display(Name = "e.g. A18 Bionic")]
        public string Processor { get; set; } = null!;

        [Display(Name = "e.g. 8")]
        public int RAM { get; set; }

        [Display(Name = "e.g. 128GB , 256GB , 512GB")]
        public string StorageOptions { get; set; } = null!;

        [Display(Name = "e.g. IOS 18")]
        public string OperatingSystem { get; set; } = null!;

        [Display(Name = "e.g. Triple 48MP + 12MP + 12MP")]
        public string Camera { get; set; } = null!;

        [Display(Name = "e.g. 4500")]
        public int Battery { get; set; }
        [Display(Name = "e.g. 6.7-inch Super Retina XDR")]
        public string Display { get; set; } = null!;

        [Display(Name = "e.g. Black , Silver , Gold")]
        public string AvailableColors { get; set; } = null!;
        public int Quantity { get; set; }
        public IFormFile? Header { get; set; }
        public string? HeaderImage { get; set; }
        public int NumberOfExisitItems { get; set; }

    }
}
