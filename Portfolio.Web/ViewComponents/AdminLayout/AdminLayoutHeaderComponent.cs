using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}