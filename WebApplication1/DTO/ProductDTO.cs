namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public int Order { get; init; }

        public decimal Price { get; init; }

        public string ImageUrl { get; init; } = null!;

        public SectionDTO Section { get; init; } = null!;

        public BrandDTO? Brand { get; init; }
    }
}
