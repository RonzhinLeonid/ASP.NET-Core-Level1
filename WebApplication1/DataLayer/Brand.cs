using DataLayer.Base;
using DataLayer.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    [Index(nameof(Name), IsUnique = true)]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
