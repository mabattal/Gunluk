using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class NotController : Controller
    {
        NotManager notManager = new NotManager(new EfNotRepository());
        public IActionResult Index()
        {
            List<Not> notListesi = notManager.GetNotListWithYazar();
            var values = notListesi.Where(not => not.NotSil == false).ToList();

            return View(values);
        }
    }
}
