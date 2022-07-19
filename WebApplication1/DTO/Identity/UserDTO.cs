using DataLayer.Identity;

namespace DTO.Identity
{
    public abstract class UserDTO
    {
        public User User { get; init; } = null!;
    }
}
