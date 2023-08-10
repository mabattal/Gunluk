using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Gunluk.Controllers
{
    public class NotController : Controller
    {
        NotManager notManager = new NotManager(new EfNotRepository());
        public IActionResult Index(DateTime? tarih = null)
        {
            if (!tarih.HasValue)
            {
                tarih = DateTime.Today; // Bugünün tarihi
            }

            ViewBag.SelectedDate = tarih?.ToString("yyyy-MM-dd");

            Context context = new Context();
            var yazarMail = User.Identity.Name;
            var yazarId = context.Yazars.Where(x => x.Mail == yazarMail).Select(y => y.YazarId).FirstOrDefault();

            List<Not> notListesi = notManager.GetNotListByYazar(yazarId);
            var values = notListesi.Where(not => not.NotSil == false && not.Tarih.Date == tarih.Value.Date).ToList();

            return View(values);
        }


        public IActionResult NotOku(int id)
        {
            var values = notManager.GetNotById(id);
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
                Context context = new Context();
                var yazarMail = User.Identity.Name;
                var yazarId = context.Yazars.Where(x => x.Mail == yazarMail).Select(y => y.YazarId).FirstOrDefault();

                not.YazarId = yazarId;
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
            notValue.NotSil = true;
            notManager.TUpdate(notValue);
            return RedirectToAction("Index");
        }
    }
}
