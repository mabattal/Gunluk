using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class YazarController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());
        public IActionResult Index()
        {
            var values = yazarManager.GetListAll();
            return View(values);
        }
    }
}
