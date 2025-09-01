using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Models;
using System.Security.Claims;

namespace Portfolio.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController(PortfolioContext context) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //Fast Fail
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = context.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            if (user is null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim("fullName",string.Join(" ",user.FirstName,user.LastName))
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false

            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                          new ClaimsPrincipal(claimsIdentity),
                                          authProperties);

            HttpContext.Session.SetString("UserName", user.Username);

            return RedirectToAction("Index", "Statistics");



        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserName");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}