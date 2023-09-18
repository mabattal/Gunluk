using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Gunluk.Controllers
{
    public class YazarController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());
        
        [HttpGet]
        public async Task<IActionResult> YazarDuzenle()
        {
            var yazarId = HttpContext.Session.GetInt32("YazarId");
            if (yazarId != null)
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:44346/api/YazarApi/" + yazarId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonCalisan = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<Yazar>(jsonCalisan);
                    return View(values);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YazarDuzenle(Yazar yazar)
        {
            YazarValidator yazarValidator = new YazarValidator();
            ValidationResult results = yazarValidator.Validate(yazar);
            if (results.IsValid)
            {
                var httpClient = new HttpClient();
                var jsonCalisan = JsonConvert.SerializeObject(yazar);
                var content = new StringContent(jsonCalisan, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:44346/api/YazarApi", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Not");
                }
                return View(yazar);
            }                
            return View();
        }
    }
}
