using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Components
{
	public class UserInfoViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke() => User.Identity!.IsAuthenticated
	   ? View("UserInfo")
	   : View();
	}
}
