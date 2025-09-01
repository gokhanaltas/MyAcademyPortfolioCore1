using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class SettingController : Controller
    {
        private readonly PortfolioContext context;

        public SettingController(PortfolioContext context)
        {
            this.context = context;
        }

        // -----------------------------
        // Kullanıcı Listesi
        // -----------------------------
        public IActionResult UserList()
        {
            var userList = context.Users.ToList();
            return View(userList);
        }

        // -----------------------------
        // Mevcut Şifre Kontrolü
        // -----------------------------
        [HttpGet]
        public IActionResult UserPassword(int id)
        {
            var user = context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public IActionResult UserPassword(int UserId, string Password)
        {
            var user = context.Users.Find(UserId);
            if (user == null) return NotFound();

            if (user.Password != Password)
            {
                ModelState.AddModelError("Password", "Mevcut şifre hatalı.");
                return View(user);
            }

            TempData["Success"] = "Şifre doğrulandı, yeni şifre belirleyebilirsiniz.";
            return RedirectToAction("UserPasswordChange", new { id = UserId });
        }

        // -----------------------------
        // Yeni Şifre Girme
        // -----------------------------
        [HttpGet]
        public IActionResult UserPasswordChange(int id)
        {
            var user = context.Users.Find(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult UserPasswordChange(int UserId, string NewPassword, string ConfirmPassword)
        {
            var user = context.Users.Find(UserId);
            if (user == null) return NotFound();

            if (NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError("", "Yeni şifreler eşleşmiyor.");
                return View(user);
            }

            user.Password = NewPassword; // Hash kullanmanız önerilir
            context.SaveChanges();

            TempData["Success"] = "Şifre başarıyla değiştirildi!";
            return RedirectToAction("UserList");
        }

        // -----------------------------
        // Profil Güncelleme
        // -----------------------------
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var user = context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            var existingUser = context.Users.Find(user.UserId);
            if (existingUser == null) return NotFound();

            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                ModelState.AddModelError("FirstName", "İsim alanı boş bırakılamaz.");
                return View(user);
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Username = user.Username;

            context.SaveChanges();
            TempData["Success"] = "Profil güncellendi!";
            return RedirectToAction("UserList");
        }

    }
}
