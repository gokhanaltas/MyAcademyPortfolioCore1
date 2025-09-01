using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultSkillsComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultSkillsComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Skills.ToList();
            return View(value);
        }
    }
}
