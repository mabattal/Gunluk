using ApiLayer.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult CalisanListe()
        {
            using var context = new Context();
            var values = context.Calisans.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CalisanEkle(Calisan calisan)
        {
            using var context = new Context();
            context.Add(calisan);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult CalisanGetir(int id)
        {
            using var context = new Context();
            var calisan = context.Calisans.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return Ok(calisan);
        }

        [HttpDelete("{id}")]
        public IActionResult CalisanSil(int id)
        {
            using var context = new Context();
            var calisan = context.Calisans.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }
            context.Remove(calisan);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult CalisanGuncelle(Calisan calisan)
        {
            using var context = new Context();
            var cls = context.Find<Calisan>(calisan.Id);
            if (cls == null)
            {
                return NotFound();
            }
            cls.Ad = calisan.Ad;
            context.Update(cls);
            context.SaveChanges();
            return Ok();
        }
    }
}
