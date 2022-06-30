using Microsoft.AspNetCore.Identity;

namespace DataLayer.DTO.Identity
{
    public class AddLoginDTO : UserDTO
    {
        public UserLoginInfo UserLoginInfo { get; init; } = null!;
    }
}
