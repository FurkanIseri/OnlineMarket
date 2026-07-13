using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Services.Contracts;
using Entities.RequestParameters;
using OnlineMarketApp.Models;
using Entities.Dtos;

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

        public IActionResult Index([FromQuery]ProductRequestParameter p)
        {
            ViewData["Title"] = "Product";
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.Name);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images",file.FileName);
                _manager.ProductService.CreateOneProduct(productDto);
                TempData["success"] = $"{productDto.ProductName} has been created.";
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
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto,IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot,images",file.FileName);
            using (var stream = new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            productDto.ImageUrl = String.Concat("/images/",file.FileName);
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(productDto);
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