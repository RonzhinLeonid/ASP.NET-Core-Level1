using DataLayer.Base;
using DataLayer.Base.Interfaces;

namespace DataLayer
{
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int SectionId { get; set; }

        public int? BrandId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
