using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Services.Contracts;

namespace OnlineMarketApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServicerManager _manager;

        public ProductController(IServicerManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var products = _manager.ProductService.GetAllProducts(false);
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            var products = _manager.ProductService.GetOneProduct(id,true);
            return View(products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Delete([FromRoute] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}