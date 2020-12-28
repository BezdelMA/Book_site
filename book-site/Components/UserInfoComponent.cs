using Microsoft.AspNetCore.Mvc;

namespace book_site.Components
{
    public class UserInfoComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => User.Identity?.IsAuthenticated == true
            ? View("UserInfo")
            : View();
    }
}
