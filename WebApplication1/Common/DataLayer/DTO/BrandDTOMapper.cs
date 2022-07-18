using System.Diagnostics.CodeAnalysis;

namespace DataLayer.DTO
{
    public static class BrandDTOMapper
    {
        [return: NotNullIfNotNull("brand")]
        public static BrandDTO? ToDTO(this Brand? brand) => brand is null
            ? null
            : new()
            {
                Id = brand.Id,
                Name = brand.Name,
                Order = brand.Order,
                ProductsCount = brand.Products.Count,
            };

        [return: NotNullIfNotNull("brand")]
        public static Brand? FromDTO(this BrandDTO? brand) => brand is null
            ? null
            : new()
            {
                Id = brand.Id,
                Name = brand.Name,
                Order = brand.Order,
                Products = new Product[brand.ProductsCount],
            };

        public static IEnumerable<BrandDTO> ToDTO(this IEnumerable<Brand>? brands) => brands?.Select(ToDTO)!;

        public static IEnumerable<Brand> FromDTO(this IEnumerable<BrandDTO>? brands) => brands?.Select(FromDTO)!;
    }
}
