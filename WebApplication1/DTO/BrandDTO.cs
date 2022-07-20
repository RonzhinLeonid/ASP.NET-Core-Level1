namespace DTO
{
    public class BrandDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public int Order { get; init; }

        public IEnumerable<int> ProductIds { get; init; } = null!;
    }
}
