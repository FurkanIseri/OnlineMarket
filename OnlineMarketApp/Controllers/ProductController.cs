using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketApp.Models;
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

        public IActionResult Index(ProductRequestParameter p)
        {
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
               Products = products,
               Pagination = pagination 
            });
        }
        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);            
        }
    }
}