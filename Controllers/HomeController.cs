using ClassicModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassicModels.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository repo;

        public HomeController(ProductRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var vm = new ProductLineViewModel();
            vm.ProductLines = this.repo.ProductLines();
            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel());
        }
    }
}