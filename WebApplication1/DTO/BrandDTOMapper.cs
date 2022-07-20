using DataLayer;
using System.Diagnostics.CodeAnalysis;

namespace DTO
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
                ProductIds = brand.Products.Select(p => p.Id),
            };

        [return: NotNullIfNotNull("brand")]
        public static Brand? FromDTO(this BrandDTO? brand) => brand is null
            ? null
            : new()
            {
                Id = brand.Id,
                Name = brand.Name,
                Order = brand.Order,
                Products = brand.ProductIds.Select(id => new Product { Id = id }).ToArray(),
            };

        public static IEnumerable<BrandDTO> ToDTO(this IEnumerable<Brand>? brands) => brands?.Select(ToDTO)!;

        public static IEnumerable<Brand> FromDTO(this IEnumerable<BrandDTO>? brands) => brands?.Select(FromDTO)!;
    }
}
