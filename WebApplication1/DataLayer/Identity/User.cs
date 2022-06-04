using Microsoft.AspNetCore.Identity;

namespace DataLayer.Identity
{
	public class User : IdentityUser
	{
		public override string ToString() => UserName;
	}
}
