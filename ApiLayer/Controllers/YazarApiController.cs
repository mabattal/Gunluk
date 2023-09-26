using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarApiController : ControllerBase
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        [HttpGet("{id}")]
        public IActionResult YazarGuncelle(int id)
        {
            var values = yazarManager.GetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult YazarGuncelle(Writer writer)
        {
            WriterValidator yazarValidator = new WriterValidator();
            ValidationResult results = yazarValidator.Validate(writer);
            if (results.IsValid)
            {
                yazarManager.Update(writer);
                return Ok();
            }
            return NotFound();
        }
    }
}
