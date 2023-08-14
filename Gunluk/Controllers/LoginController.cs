using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gunluk.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Yazar yazar)
        {
            var foundYazar = yazarManager.GetByLogin(yazar.Mail, yazar.Sifre);

            if (foundYazar != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, yazar.Mail),
                    new Claim("YazarId", foundYazar.YazarId.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Not");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}