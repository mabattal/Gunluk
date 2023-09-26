using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace Gunluk.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Index(Writer writer)
        {
            string url = writer.Mail;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/LoginApi/{url}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Writer>(jsondata);
                if (values != null)
                {

                    if (values.Password == writer.Password)
                    {

                        HttpContext.Session.SetInt32("YazarId", values.Id); // YazarId'yi oturuma ekler

                        return RedirectToAction("Index", "Not", new { id = values.Id });
                    }
                }
                return View();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}