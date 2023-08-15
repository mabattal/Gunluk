using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
