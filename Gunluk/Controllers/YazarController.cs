using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class YazarController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());
        public IActionResult Index()
        {
            List<Yazar> yazarListesi = yazarManager.GetListAll();
            var values = yazarListesi.Where(yazar => yazar.YazarSil == false).ToList();
           
            return View(values);
        }
    }
}
