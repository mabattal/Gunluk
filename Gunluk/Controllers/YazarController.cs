using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class YazarController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());
        public IActionResult Index()
        {
            List<Yazar> yazarListesi = yazarManager.GetListAll();
            var values = yazarListesi.Where(yazar => yazar.YazarSil == false).ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult YazarDuzenle()
        {
            var yazarValues = yazarManager.TGetById(1);
            return View(yazarValues);
        }

        [HttpPost]
        public IActionResult YazarDuzenle(Yazar yazar)
        {
            YazarValidator yazarValidator = new YazarValidator();
            ValidationResult results = yazarValidator.Validate(yazar);
            if (results.IsValid)
            {
                yazarManager.TUpdate(yazar);
                return RedirectToAction("Index", "Not");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
