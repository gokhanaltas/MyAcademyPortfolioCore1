using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using System;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultAboutComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponent(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutList = await _context.Abouts.ToListAsync(); // Bu List<About> döner
            return View(aboutList); // Razor'daki @model List<About> ile eşleşmeli
        }
    }
}
