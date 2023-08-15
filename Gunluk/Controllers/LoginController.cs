using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Gunluk.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Yazar yazar)
        {
            var httpClient = new HttpClient();
            var jsonCalisan = JsonConvert.SerializeObject(yazar);
            StringContent content = new StringContent(jsonCalisan, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/LoginApi", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(jsonCalisan);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}