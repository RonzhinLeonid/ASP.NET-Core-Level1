using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogData _blogData;
        private readonly IMapper _mapper;

        public BlogsController(IBlogData BlogData, IMapper mapper)
        {
            _blogData = BlogData;
            _mapper = mapper;
        }

        public IActionResult Index(int numberPage, int countBlogInPage = 3)
        {
            IEnumerable<Blog> blogs;

            if (numberPage is { } page && countBlogInPage > 0)
            {
                blogs = _blogData.Get(page * countBlogInPage, countBlogInPage);
            }
            else
                blogs = _blogData.GetBlogs();

            ViewBag.PagesCount = countBlogInPage > 0
                ? (int?)Math.Ceiling(_blogData.GetCount() / (double)countBlogInPage)
                : null!;

            return View(blogs.Select(x => _mapper.Map<Blog, BlogViewModel>(x)));
        }

        public IActionResult ShopBlog()
        {
            return View();
        }
    }
}
