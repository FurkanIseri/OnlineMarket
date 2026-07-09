using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace OnlineMarketApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServicerManager _manager;

        public ProductController(IServicerManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);            
        }
    }
}