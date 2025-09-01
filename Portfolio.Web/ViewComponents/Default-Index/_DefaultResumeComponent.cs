using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using System;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultResumeComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultResumeComponent(PortfolioContext context)
        {
            _context = context;
        }
        
            public async Task<IViewComponentResult> InvokeAsync()
        {
            var educationList = await _context.Educations.ToListAsync(); // List<Education> döner
            return View(educationList); // Razor'daki @model List<Education> ile eşleşmeli
        }
    }
}
    
