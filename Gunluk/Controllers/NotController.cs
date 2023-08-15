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
    public class NotController : Controller
    {
        NotManager notManager = new NotManager(new EfNotRepository());

        public async Task<IActionResult> Index(DateTime? tarih = null)
        {
            if (!tarih.HasValue)
            {
                tarih = DateTime.Today; // Bugünün tarihi
            }
            ViewBag.SelectedDate = tarih?.ToString("yyyy-MM-dd");

            var yazarIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "YazarId");
            if (yazarIdClaim != null && int.TryParse(yazarIdClaim.Value, out int yazarId))
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/NotApi");
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var notListesi = JsonConvert.DeserializeObject<List<Not>>(jsonString);

                var values = notListesi.Where(not => not.Tarih.Date == tarih.Value.Date && not.YazarId == yazarId).ToList();
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NotOku(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/NotApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonCalisan = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Not>(jsonCalisan);
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
        public async Task<IActionResult> NotEkle(Not not)
        {
            var httpClient = new HttpClient();
            var jsonCalisan = JsonConvert.SerializeObject(not);
            StringContent content = new StringContent(jsonCalisan, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/NotApi", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(jsonCalisan);
        }

        public async Task<IActionResult> NotSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7183/api/NotApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
