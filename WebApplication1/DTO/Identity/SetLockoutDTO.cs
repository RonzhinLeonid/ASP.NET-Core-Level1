namespace DTO.Identity
{
    public class SetLockoutDTO : UserDTO
    {
        public DateTimeOffset? LockoutEnd { get; init; }
    }
}
