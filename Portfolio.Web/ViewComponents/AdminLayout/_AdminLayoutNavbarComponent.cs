using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
