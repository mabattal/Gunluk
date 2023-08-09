using BusinessLayer.Concrete;
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
            List<Yazar> yazarListesi = yazarManager.GetListAll();
            var dataValue = yazarListesi.Where(x => x.YazarSil == false && x.Mail == yazar.Mail && x.Sifre == yazar.Sifre).ToList();
            if(dataValue != null)
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
            else
            {
                return View();
            }
        }
    }
}