using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultProjectsComponent(PortfolioContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categoriesWithProjects = context.Categories.Include(x =>x.Projects).ToList();
            return View(categoriesWithProjects);
        }
    }
}
