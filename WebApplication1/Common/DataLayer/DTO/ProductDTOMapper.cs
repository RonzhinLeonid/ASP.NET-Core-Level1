using System.Diagnostics.CodeAnalysis;

namespace DataLayer.DTO
{
    public static class ProductDTOMapper
    {
        [return: NotNullIfNotNull("product")]
        public static ProductDTO? ToDTO(this Product? product) => product is null
            ? null
            : new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand.ToDTO(),
                Section = product.Section.ToDTO(),
            };

        [return: NotNullIfNotNull("product")]
        public static Product? FromDTO(this ProductDTO? product) => product is null
            ? null
            : new Product
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand.FromDTO(),
                Section = product.Section.FromDTO(),
            };

        public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<Product>? products) => products?.Select(ToDTO)!;

        public static IEnumerable<Product> FromDTO(this IEnumerable<ProductDTO>? products) => products?.Select(FromDTO)!;
    }
}
