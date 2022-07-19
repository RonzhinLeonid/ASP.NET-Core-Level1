namespace DTO
{
    public class SectionDTO
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public int Order { get; init; }

        public int? ParentId { get; init; }
    }
}
