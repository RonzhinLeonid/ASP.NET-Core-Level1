using DataLayer.Base;

namespace DataLayer
{
    public class Employee : Entity
    {
        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? Patronymic { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"(id:{Id}){LastName} {FirstName} {Patronymic} - age:{Age}";
        }
    }
}
