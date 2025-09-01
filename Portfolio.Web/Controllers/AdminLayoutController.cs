using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
