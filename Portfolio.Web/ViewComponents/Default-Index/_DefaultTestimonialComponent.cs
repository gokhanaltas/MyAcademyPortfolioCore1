using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultTestimonialComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultTestimonialComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var testimonials = _context.Testimonials.ToList(); // Veritabanındaki tüm referanslar
            return View(testimonials);
        }
    }
}
