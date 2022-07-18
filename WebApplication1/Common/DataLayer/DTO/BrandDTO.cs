namespace DataLayer.DTO
{
    public class BrandDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public int Order { get; init; }

        public int ProductsCount { get; init; }
    }
}
