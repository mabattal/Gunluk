using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class NotController : Controller
    {
        NotManager notManager = new NotManager(new EfNotRepository());
        public IActionResult Index()
        {
            var values = notManager.GetNotListWithYazar();
            return View(values);
        }
    }
}
