using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class NotController : Controller
    {
        NotManager notManager = new NotManager(new EfNotRepository());
        public IActionResult Index()
        {
            List<Not> notListesi = notManager.GetNotListByYazar(1);
            var values = notListesi.Where(not => not.NotSil == false).ToList();

            return View(values);
        }

        public IActionResult NotOku(int id)
        {
            var values = notManager.GetNotById(id);
            return View(values);
        }
        public IActionResult YazaraGoreNotListele(int id)
        {
            List<Not> notListesi = notManager.GetNotListByYazar(id);
            var values = notListesi.Where(not => not.NotSil == false).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NotEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NotEkle(Not not)
        {
            NotValidator notValidator = new NotValidator();
            ValidationResult results = notValidator.Validate(not);
            if (results.IsValid)
            {
                not.YazarId = 1;
                notManager.TInsert(not);
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

        public IActionResult NotSil(int id)
        {
            var notValue = notManager.TGetById(id);
            notManager.TDelete(notValue);
            return RedirectToAction("Index");
        }
    }
}
