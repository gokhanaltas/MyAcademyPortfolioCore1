using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class UserMessageController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var userMessage = context.UserMessages.ToList();
            return View(userMessage);
        }

        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = context.UserMessages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = context.UserMessages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CreateUserMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUserMessage(UserMessage userMessage)
        {
            context.UserMessages.Add(userMessage);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUserMessage(int id)
        {
            var userMessage = context.UserMessages.Find(id);
            context.UserMessages.Remove(userMessage);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //public IActionResult MessageDetail(int id)
        //{
        //    var MessageDetail = context.UserMessages.FirstOrDefault(x => x.UserMessageId == id);
        //    return RedirectToAction("Index", "UserMessage");
        //}
        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            var userMessage = context.UserMessages.FirstOrDefault(x => x.UserMessageId == id);
            if (userMessage == null)
                return NotFound();

            return View(userMessage);
        }

        [HttpPost]
        public IActionResult MessageDetail(UserMessage model)
        {
            var userMessage = context.UserMessages.FirstOrDefault(x => x.UserMessageId == model.UserMessageId);
            if (userMessage != null)
            {
                userMessage.IsRead = model.IsRead;
                // diğer alanlara dokunmuyorsan eski değerler korunur
                context.SaveChanges();
            }
            return RedirectToAction("Index", "UserMessage");
        }

    }


}
    //public IActionResult UpdateUserMessage(int id)
    //{
    //    var userMessage = context.UserMessages.Find(id);
    //    return View(userMessage);
    //}
    //[HttpPost]
    //public IActionResult UpdateUserMessage(UserMessage userMessage)
    //{
    //    context.UserMessages.Update(userMessage);
    //    context.SaveChanges();
    //    return RedirectToAction("Index");
    //}

