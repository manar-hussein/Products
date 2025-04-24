
using Microsoft.AspNetCore.Identity;

namespace Products.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? SSN { get; set; } = null!;
        public List<Product>? SalesProducts { get; set; } = new List<Product>();
    }
}
