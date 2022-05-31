using DataLayer.Base;
using DataLayer.Base.Interfaces;

namespace DataLayer
{

    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int? ParentId { get; set; }
    }
}