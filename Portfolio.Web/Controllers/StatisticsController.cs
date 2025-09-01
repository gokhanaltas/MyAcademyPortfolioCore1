using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly PortfolioContext context;

        public StatisticsController(PortfolioContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            // Mevcut 12 istatistik
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.skillAverage = context.Skills.Any() ? context.Skills.Average(x => x.Percentage).ToString("00.00") : "0.00";
            ViewBag.unreadMessageCount = context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.lastMessageOwner = context.UserMessages.OrderByDescending(x => x.UserMessageId).Select(x => x.Name).FirstOrDefault();
            ViewBag.experienceYear = context.Experiences.Any() ? DateTime.Now.Year - context.Experiences.Min(x => x.StartYear) : 0;
            ViewBag.companyCount = context.Experiences.Select(x => x.Company).Distinct().Count();
            ViewBag.reviewAverage = context.Testimonials.Any() ? context.Testimonials.Average(x => x.Review).ToString("0.0") : "0.0";
            ViewBag.maxReviewOwner = context.Testimonials.OrderByDescending(x => x.Review).Select(x => x.Name).FirstOrDefault();
            ViewBag.totalMessageCount = context.UserMessages.Count();
            ViewBag.readMessageCount = context.UserMessages.Count(x => x.IsRead);
            ViewBag.skillCount = context.Skills.Count();
            ViewBag.projectCompletedCount = context.Projects.Count(); // tüm projeler sayılıyor, IsCompleted yok

            // Yeni 4 istatistik (mevcut tablolar üzerinden)
            ViewBag.newProjectCount = context.Projects.Count(x => x.ProjectId > 0); // örnek: tüm projeler
            ViewBag.notCompletedProjectCount = context.Projects.Count() - ViewBag.projectCompletedCount;
            ViewBag.maxSkillPercentage = context.Skills.Any() ? context.Skills.Max(x => x.Percentage) : 0;
            ViewBag.minSkillPercentage = context.Skills.Any() ? context.Skills.Min(x => x.Percentage) : 0;

            return View();
        }
    }
}
