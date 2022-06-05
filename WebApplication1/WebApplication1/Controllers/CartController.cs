using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;

        public CartController(ICartService cartService) => _CartService = cartService;

        public IActionResult Index() => View(_CartService.GetViewModel());

        public IActionResult Add(int Id)
        {
            _CartService.Add(Id);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Decrement(int Id)
        {
            _CartService.Decrement(Id);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Remove(int Id)
        {
            _CartService.Remove(Id);
            return RedirectToAction("Index", "Cart");
        }
    }
}
