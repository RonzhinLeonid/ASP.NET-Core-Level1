using DataLayer;
using Microsoft.Extensions.Logging;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;

namespace WebStore.Services.Services.InMemory
{
    [Obsolete("Используйте InSqlBlogData")]
    public class InMemoryBlogData : IBlogData
    {
        private ILogger<InMemoryBlogData> _logger;
        private ICollection<Blog> _blogs;

        public InMemoryBlogData(ILogger<InMemoryBlogData> logger)
        {
            _blogs = TestData.Blogs;
            _logger = logger;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _blogs;
        }
        public IEnumerable<Blog> Get(int skip, int take)
        {
            IEnumerable<Blog> query = _blogs;

            if (take == 0) return Enumerable.Empty<Blog>();

            if (skip > 0)
            {
                if (skip > _blogs.Count) return Enumerable.Empty<Blog>();

                query = query.Skip(skip);
            }

            return query.Take(take);
        }

        public int GetCount()
        {
            return _blogs.Count;
        }
    }
}
