using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class RegisterController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Yazar yazar)
        {
            YazarValidator yazarValidator = new YazarValidator();
            ValidationResult results = yazarValidator.Validate(yazar);
            if(results.IsValid)
            {
                yazarManager.TInsert(yazar);
                return RedirectToAction("Index", "Not");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
