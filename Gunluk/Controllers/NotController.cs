using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Gunluk.Controllers
{
    public class NotController : Controller
    {
        private readonly IValidator<Note> _noteValidator;
        public NotController(IValidator<Note> noteValidator)
        {
            _noteValidator = noteValidator;
        }
        public async Task<IActionResult> Index(DateTime? tarih = null)
        {

            var yazarId = HttpContext.Session.GetInt32("YazarId");
            if (!tarih.HasValue)
            {
                tarih = DateTime.Today; // Bugünün tarihi
            }
            ViewBag.SelectedDate = tarih?.ToString("yyyy-MM-dd");
            string yenitarih = tarih?.ToString("yyyy-MM-dd");
            
            if (yazarId != null)
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync($"https://localhost:44346/api/NotApi?yazarId={yazarId}&tarih={yenitarih}");
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var notListesi = JsonConvert.DeserializeObject<List<Note>>(jsonString);

                return View(notListesi);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NotOku(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44346/api/NotApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonCalisan = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Note>(jsonCalisan);
               
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult NotEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NotEkle(Note note)
        {
            var result = _noteValidator.Validate(note);
            if (result.IsValid)
            {
                var httpClient = new HttpClient();
                note.WriterId = Convert.ToInt32(HttpContext.Session.GetInt32("YazarId"));
                var jsonNot = JsonConvert.SerializeObject(note);
                StringContent content = new StringContent(jsonNot, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:44346/api/NotApi", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(jsonNot);
            }
           return View();
            
        }

        public async Task<IActionResult> NotSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44346/api/NotApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
