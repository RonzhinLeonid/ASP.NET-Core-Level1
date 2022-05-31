using DataLayer;

namespace WebApplication1.Services.Interfaces
{
    public interface IBlogData
    {
        IEnumerable<Blog> GetBlogs();
    }
}
