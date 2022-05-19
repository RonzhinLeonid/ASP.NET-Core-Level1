using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShopBlog()
        {
            return View();
        }
    }
}
