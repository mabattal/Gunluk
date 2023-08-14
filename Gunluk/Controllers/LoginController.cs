using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            Context context = new Context();
            var dataValue = context.Yazars.FirstOrDefault(x => x.YazarSil == false && x.Mail == yazar.Mail && x.Sifre == yazar.Sifre);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, yazar.Mail)
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