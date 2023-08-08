using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
