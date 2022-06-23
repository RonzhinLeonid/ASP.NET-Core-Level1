using DataLayer.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
