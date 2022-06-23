using ContextDB.DAL;
using DataLayer;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.InSQL
{
    public class InSQLBlogData : IBlogData
    {
        private ILogger<InSQLBlogData> _logger;
        private readonly WebStoreDB _context;

        public InSQLBlogData(WebStoreDB context, ILogger<InSQLBlogData> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _context.Blogs;
        }

        public IEnumerable<Blog> Get(int skip, int take)
        {
            if (take == 0) return Enumerable.Empty<Blog>();

            IEnumerable<Blog> query = _context.Blogs;

            if (skip > 0)
                query = query.Skip(skip);

            return query.Take(take);
        }

        public int GetCount()
        {
            return _context.Blogs.Count();
        }
    }
}
