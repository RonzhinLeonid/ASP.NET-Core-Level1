using Microsoft.AspNetCore.Identity;

namespace DTO.Identity
{
    public class AddLoginDTO : UserDTO
    {
        public UserLoginInfo UserLoginInfo { get; init; } = null!;
    }
}
