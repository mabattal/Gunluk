using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class YazarController : Controller
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());
        
        [HttpGet]
        public IActionResult YazarDuzenle()
        {
            Context context = new Context();
            var yazarMail = User.Identity.Name;
            var yazarId = context.Yazars.Where(x => x.Mail == yazarMail).Select(y => y.YazarId).FirstOrDefault();
            

            var yazarValues = yazarManager.TGetById(yazarId);
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
