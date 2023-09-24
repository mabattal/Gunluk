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
    public class RegisterApiController : ControllerBase
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        [HttpPost]
        public IActionResult Index(Yazar yazar)
        {
            YazarValidator yazarValidator = new YazarValidator();
            ValidationResult results = yazarValidator.Validate(yazar);
            if (results.IsValid)
            {
                yazarManager.Insert(yazar);
                return Ok();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return NotFound();
        }
    }
}
