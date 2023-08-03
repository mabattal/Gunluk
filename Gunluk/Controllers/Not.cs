using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class Not : Controller
    {
        NotManager notManager = new NotManager(new EfNotRepository());
        public IActionResult Index()
        {
            var values = notManager.GetListAll();
            return View(values);
        }
    }
}
