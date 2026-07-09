using Microsoft.AspNetCore.Mvc;
using OnlineMarketApp.Models;

namespace OnlineMarketApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
