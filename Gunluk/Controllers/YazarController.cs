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
                    var values = JsonConvert.DeserializeObject<Writer>(jsonCalisan);
                    return View(values);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YazarDuzenle(Writer writer)
        {
            WriterValidator yazarValidator = new WriterValidator();
            ValidationResult results = yazarValidator.Validate(writer);
            if (results.IsValid)
            {
                var httpClient = new HttpClient();
                var jsonCalisan = JsonConvert.SerializeObject(writer);
                var content = new StringContent(jsonCalisan, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:44346/api/YazarApi", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Not");
                }
                return View(writer);
            }                
            return View();
        }
    }
}
