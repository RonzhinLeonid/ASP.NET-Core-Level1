using Microsoft.AspNetCore.Identity;

namespace DataLayer.Identity
{
	public class Role : IdentityRole
	{
		public const string Administrators = "Administrators";
		public const string Users = "Users";
	}
}
