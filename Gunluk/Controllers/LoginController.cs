using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(Yazar yazar)
        {
            List<Yazar> yazarListesi = yazarManager.GetListAll();
            var dataValue = yazarListesi.Where(x => x.YazarSil == false && x.Mail == yazar.Mail && x.Sifre == yazar.Sifre).ToList();
            if(dataValue != null)
            {
                HttpContext.Session.SetString("username", yazar.Mail);
                return RedirectToAction("Index", "Not");
            }
            else
            {
                return View();
            }            
        }
    }
}
