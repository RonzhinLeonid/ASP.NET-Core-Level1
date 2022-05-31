using DataLayer;
using WebApplication1.Data;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class InMemoryBlogData : IBlogData
    {
        public IEnumerable<Blog> GetBlogs()
        {
            return TestData.Blogs;
        }
    }
}
