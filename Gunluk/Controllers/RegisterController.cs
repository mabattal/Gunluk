using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
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
        private readonly IValidator<Writer> _writerValidator;

        public RegisterController(IValidator<Writer> writerValidator)
        {
            _writerValidator = writerValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var results = _writerValidator.Validate(writer);
            if (results.IsValid) 
            {
                var httpClient = new HttpClient();
                var jsonYazar = JsonConvert.SerializeObject(writer);
                StringContent content = new StringContent(jsonYazar, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:44346/api/RegisterApi", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
