using DataLayer.Base.Interfaces;

namespace DataLayer.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public string Name { get; set; } = null!;
    }
}
