using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] IProductData ProductData)
        {
            var products = ProductData
               .GetProducts(new() { PageNumber = 1, PageSize = 6 })
               .Items
               .OrderBy(p => p.Order)
               .ToView();

            ViewBag.Products = products;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contacts() => View();

        public IActionResult Error404() => View();
    }
}