using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Gunluk.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Yazar yazar)
        {
            var httpClient = new HttpClient();
            var jsonYazar = JsonConvert.SerializeObject(yazar);
            StringContent content = new StringContent(jsonYazar, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44346/api/RegisterApi", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }            
            return View(jsonYazar);
        }
    }
}
