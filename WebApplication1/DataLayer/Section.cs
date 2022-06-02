using DataLayer.Base;
using DataLayer.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Index(nameof(Name), IsUnique = false)]
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Section? Parent { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}