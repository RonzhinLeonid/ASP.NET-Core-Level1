using ContextDB.DAL;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services.InSQL
{
    public class InSQLProductData : IProductData
    {
        private ILogger<InSQLProductData> _logger;
        private readonly WebStoreDB _context;

        public InSQLProductData(WebStoreDB context, ILogger<InSQLProductData> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Section> GetSections() => _context.Sections.Include(s => s.Products);

        public Section? GetSectionById(int Id) => _context.Sections
       .Include(s => s.Products)
       .FirstOrDefault(s => s.Id == Id);

        public IEnumerable<Brand> GetBrands() => _context.Brands.Include(b => b.Products);

        public Brand? GetBrandById(int Id) => _context.Brands
       .Include(b => b.Products)
       .FirstOrDefault(b => b.Id == Id);

        public Page<Product> GetProducts(ProductFilter? Filter = null)
        {
            IQueryable<Product> query = _context.Products
               .Include(p => p.Section)
               .Include(p => p.Brand)
               .OrderBy(p => p.Order);

            if (Filter is { Ids: { Length: > 0 } ids })
                query = query.Where(p => ids.Contains(p.Id));
            else
            {
                if (Filter is { SectionId: { } section_id })
                    query = query.Where(x => x.SectionId == section_id);

                if (Filter is { BrandId: { } brand_id })
                    query = query.Where(x => x.BrandId == brand_id);
            }

            var count = query.Count();

            if (Filter is { PageSize: > 0 and var page_size, PageNumber: > 0 and var page })
                query = query
                   .Skip((page - 1) * page_size)
                   .Take(page_size);

            return new(query, Filter?.PageNumber ?? 0, Filter?.PageSize ?? 0, count);
        }

        public Product? GetProductById(int Id) => _context.Products
       .Include(p => p.Section)
       .Include(p => p.Brand)
       .FirstOrDefault(p => p.Id == Id);
    }
}
