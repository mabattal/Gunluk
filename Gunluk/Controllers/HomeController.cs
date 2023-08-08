using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
