using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Gunluk.Controllers
{
    public class CalisanController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7183/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult CalisanEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalisanEkle(Class1 class1)
        {
            var httpClient = new HttpClient();
            var jsonCalisan = JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonCalisan, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7183/api/Default", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(jsonCalisan);
        }
    }

    public class Class1
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
