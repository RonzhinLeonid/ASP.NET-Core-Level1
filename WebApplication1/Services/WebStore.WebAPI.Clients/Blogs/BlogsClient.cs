using DataLayer;
using WebStore.Interfaces.Services;
using WebStore.WebAPI.Clients.Base;

namespace WebStore.WebAPI.Clients.Blogs
{
    public class BlogsClient : BaseClient, IBlogData
    {
        public BlogsClient(HttpClient Client)
            : base(Client, WebAPIAddresses.V1.Blogs)
        {
        }

        public IEnumerable<Blog> Get(int Skip, int Take)
        {
            var result = Get<IEnumerable<Blog>>($"{Address}/[{Skip}:{Take}]");
            return result ?? Enumerable.Empty<Blog>();
        }

        public IEnumerable<Blog> GetBlogs()
        {
            var result = Get<IEnumerable<Blog>>(Address);
            return result ?? Enumerable.Empty<Blog>();
        }

        public int GetCount()
        {
            var result = Get<int>($"{Address}/count");
            return result;
        }
    }
}
