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
                List<Note> notListesi = notManager.GetNoteListByWriter(yazarId);
                var values = notListesi.Where(x => x.NoteDelete == false && x.CreatedDate.Date == tarih.Value.Date).ToList();
                return Ok(values);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult NotOku(int id)
        {
            var values = notManager.GetNoteById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult NotEkle(Note note)
        {
            NoteValidator notValidator = new NoteValidator();
            ValidationResult results = notValidator.Validate(note);
            if (results.IsValid)
            {
                
                    notManager.Insert(note);
                    return Ok();
                
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult NotSil(int id)
        {
            var notValue = notManager.GetById(id);
            notValue.NoteDelete = true;
            notManager.Update(notValue);
            return Ok();
        }
    }
}
