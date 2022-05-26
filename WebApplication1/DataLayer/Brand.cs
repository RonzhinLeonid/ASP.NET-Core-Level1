using DataLayer.Base;
using DataLayer.Base.Interfaces;

namespace DataLayer
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
