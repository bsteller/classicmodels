using ClassicModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModels.Controllers
{
    public class CartController : Controller
    {
        private ProductRepository repo;

        public CartController(ProductRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("Cart/Product/{productCode}")]
        public IActionResult Index(string productCode)
        {
            var vm = new CartViewModel();
            vm.ProductLines = this.repo.ProductLines();
            return View(vm);
        }
    }
}