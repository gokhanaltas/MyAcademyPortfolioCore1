using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SocialMediaController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var socialMedia = context.SocialMedias.ToList();
            return View(socialMedia);
        }
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedias.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = context.SocialMedias.Find(id);
            return View(socialMedia);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedias.Update(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}