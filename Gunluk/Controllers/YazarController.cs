using BusinessLayer.ValidationRules;
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
            var yazarIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "YazarId");
            if (yazarIdClaim != null && int.TryParse(yazarIdClaim.Value, out int yazarId))
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/YazarApi/" + yazarId);
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
                var responseMessage = await httpClient.PutAsync("https://localhost:7183/api/YazarApi", content);
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
