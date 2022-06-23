using DataLayer;

namespace WebStore.Interfaces.Services
{
    public interface IBlogData
    {
        IEnumerable<Blog> GetBlogs();
        IEnumerable<Blog> Get(int skip, int take);
        int GetCount();
    }
}
