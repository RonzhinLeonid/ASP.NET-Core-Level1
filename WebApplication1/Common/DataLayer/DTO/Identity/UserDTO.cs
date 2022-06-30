using DataLayer.Identity;

namespace DataLayer.DTO.Identity
{
    public abstract class UserDTO
    {
        public User User { get; init; } = null!;
    }
}
