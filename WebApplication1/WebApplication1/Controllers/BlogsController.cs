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
        private readonly int _countBlogInPage = 3;

        public BlogsController(IBlogData BlogData, IMapper mapper)
        {
            _blogData = BlogData;
            _mapper = mapper;
        }

        public IActionResult Index(int numberPage)
        {
            var blogs = _blogData.GetBlogs();
            var blogs_views = blogs.Skip(_countBlogInPage * numberPage).Take(_countBlogInPage).Select(x => _mapper.Map<Blog, BlogViewModel>(x)).ToArray();

            return View(new PageBlogViewModel()
            {
                CountPage = (int)Math.Ceiling((double)blogs.Count() / _countBlogInPage),
                Blogs = blogs_views 
            });
        }

        public IActionResult ShopBlog()
        {
            return View();
        }
    }
}
