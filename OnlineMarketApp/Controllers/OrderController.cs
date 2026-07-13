using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace OnlineMarketApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServicerManager _manager;
        private readonly Cart _cart;

        public OrderController(IServicerManager manager, Cart cart)
        {
            _manager = manager;
            _cart = cart;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if(_cart.Lines.Count == 0)
            {
                ModelState.AddModelError("","Sorry your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _manager.OrderService.saveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete",new{OrderId = order.OrderId});
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}