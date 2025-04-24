using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Services;

namespace Products.Controllers
{
    [Authorize(Roles = "Saller")]
    public class SallerController : Controller
    {
        private readonly ProductServices _productServices;

        public SallerController(ProductServices productServices)
        {
            _productServices = productServices;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetBySallerIdAsync();
            return View(products);
        }
    }
}
