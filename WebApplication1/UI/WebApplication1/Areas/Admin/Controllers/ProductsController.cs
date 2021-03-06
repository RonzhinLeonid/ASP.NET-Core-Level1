using DataLayer.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.Administrators)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;
        private readonly ILogger<ProductsController> _Logger;

        public ProductsController(IProductData ProductData, ILogger<ProductsController> Logger)
        {
            _ProductData = ProductData;
            _Logger = Logger;
        }

        public IActionResult Index()
        {
            var products = _ProductData.GetProducts();
            return View(products.Items);
        }

        public IActionResult Edit(int id) => View();

        public IActionResult Delete(int id) => View();

    }
}
