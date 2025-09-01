using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Models;
using System.Linq;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultStatsComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultStatsComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var model = new StatsViewModel
            {
                SkillCount = _context.Skills.Count(),
                ExperienceCount = _context.Experiences.Count(),
                ProjectCount = _context.Projects.Count(),
                MessageCount = _context.UserMessages.Count()
            };

            return View(model);
        }
    }
}
