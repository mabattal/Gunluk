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
        public IActionResult Index(Writer writer)
        {
            //WriterValidator yazarValidator = new WriterValidator();
            //ValidationResult results = yazarValidator.Validate(writer);
            //if (results.IsValid)
            //{
                yazarManager.Insert(writer);
                return Ok();
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return NotFound();
        }
    }
}
