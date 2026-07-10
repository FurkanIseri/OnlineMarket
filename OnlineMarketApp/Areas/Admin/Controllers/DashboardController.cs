using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;

namespace OnlineMarketApp.Areas.Admin.Controllers
{
    [Area("Admin")]  
    public class DashboardController : Controller
    {
        private readonly IServicerManager _manager;
        
        // Controller base class'ın parameterless constructor'ıyla çakışmayı önler.
        [ActivatorUtilitiesConstructor]
        public DashboardController(IServicerManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var products = _manager.ProductService.GetShowcaseProducts(false).ToList();
            return View(products);
        }
    }
}