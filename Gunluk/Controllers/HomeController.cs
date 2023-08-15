using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
