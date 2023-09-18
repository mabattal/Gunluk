using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotApiController : ControllerBase
    {
        NotManager notManager = new NotManager(new EfNotRepository());

        [HttpGet]
        public IActionResult Index(int yazarId, DateTime? tarih = null)
        {
            
            if (!tarih.HasValue)
            {
                 tarih = DateTime.Today; // Bugünün tarihi
            }

            if (yazarId != null)
            {
                List<Not> notListesi = notManager.GetNotListByYazar(yazarId);
                var values = notListesi.Where(not => not.NotSil == false && not.Tarih.Date == tarih.Value.Date).ToList();
                return Ok(values);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult NotOku(int id)
        {
            var values = notManager.GetNotById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult NotEkle(Not not)
        {
            NotValidator notValidator = new NotValidator();
            ValidationResult results = notValidator.Validate(not);
            if (results.IsValid)
            {
                
                    notManager.TInsert(not);
                    return Ok();
                
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult NotSil(int id)
        {
            var notValue = notManager.TGetById(id);
            notValue.NotSil = true;
            notManager.TUpdate(notValue);
            return Ok();
        }
    }
}
