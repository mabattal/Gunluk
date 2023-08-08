using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class RegisterController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Yazar yazar)
        {
            yazarManager.TInsert(yazar);
            return RedirectToAction("Index", "Not");
        }
    }
}
