using ClassicModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModels.Controllers
{
    public class ProductLineController : Controller
    {
        private ProductRepository repo;

        public ProductLineController(ProductRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("ProductLine/{productLineId}")]
        public IActionResult Index(int productLineId)
        {
            var vm = new ProductLineViewModel();
            vm.ProductLineId = productLineId;
            vm.ProductLines = this.repo.ProductLines();
            vm.products = this.repo.ProductLine(productLineId);
            
            if (vm.products.Count < 1)
            {
                vm.PageTitle = "Not Found";
                vm.flashMessage.Status = "Error";
                vm.flashMessage.Message = "Unable to find that product line.";
            }
            else
            {
                vm.PageTitle = vm.products[0].ProductLine;
            }

            return View(vm);
        }

        [HttpGet("ProductLine/{productLineId}/Product/{productCode}")]
        public IActionResult Product(int productLineId, string productCode)
        {
            var vm = new ProductLineViewModel();
            vm.ProductLineId = productLineId;
            vm.ProductLines = this.repo.ProductLines();
            vm.product = this.repo.Product(productCode);

            if (string.IsNullOrEmpty(vm.product.ProductCode))
            {
                vm.PageTitle = "Not Found";
                vm.flashMessage.Status = "Error";
                vm.flashMessage.Message = "Unable to find that product.";
            }
            else
            {
                vm.PageTitle = vm.product.ProductName;
            }

            return View(vm);
        }
    }
}