using DataLayer;

namespace WebStore.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        Section? GetSectionById(int Id);

        IEnumerable<Brand> GetBrands();

        Brand? GetBrandById(int Id);

        Page<Product> GetProducts(ProductFilter? Filter = null);

        Product? GetProductById(int Id);
    }
}
