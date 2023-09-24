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
        public IActionResult YazarGuncelle(Yazar yazar)
        {
            YazarValidator yazarValidator = new YazarValidator();
            ValidationResult results = yazarValidator.Validate(yazar);
            if (results.IsValid)
            {
                yazarManager.Update(yazar);
                return Ok();
            }
            return NotFound();
        }
    }
}
