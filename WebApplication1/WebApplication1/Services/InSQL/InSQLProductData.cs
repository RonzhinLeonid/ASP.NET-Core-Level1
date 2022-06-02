using DataLayer;
using WebApplication1.Data;
using WebApplication1.Services.Interfaces;
using WebStore.DAL.Context;

namespace WebApplication1.Services.InSQL
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

        public IEnumerable<Section> GetSections() => _context.Sections;

        public IEnumerable<Brand> GetBrands() => _context.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter? Filter = null)
        {
            IEnumerable<Product> query = _context.Products;

            if (Filter is { SectionId: { } section_id })
                query = query.Where(x => x.SectionId == section_id);

            if (Filter is { BrandId: { } brand_id })
                query = query.Where(x => x.BrandId == brand_id);

            return query;
        }
    }
}
