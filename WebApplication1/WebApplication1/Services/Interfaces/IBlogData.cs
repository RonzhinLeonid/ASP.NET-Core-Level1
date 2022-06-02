using DataLayer;

namespace WebApplication1.Services.Interfaces
{
    public interface IBlogData
    {
        IEnumerable<Blog> GetBlogs();
        IEnumerable<Blog> Get(int skip, int take);
        int GetCount();
    }
}
