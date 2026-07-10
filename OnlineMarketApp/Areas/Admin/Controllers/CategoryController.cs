using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace OnlineMarketApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IServicerManager _manager;
        [ActivatorUtilitiesConstructor]
        public CategoryController(IServicerManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var products = _manager.CategoryService.GetAllCategories(false);
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Category category)
        {
            _manager.CategoryService.CreateOneCategory(category);
            return RedirectToAction("Index");
        }
    }
}