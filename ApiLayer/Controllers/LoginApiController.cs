using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        YazarManager yazarManager = new YazarManager(new EfYazarRepository());

        [HttpGet("{yazar}")]
        public async Task<IActionResult> Index(string yazar)
        {
            var foundYazar = yazarManager.GetByLogin(yazar);

            if (foundYazar != null)
            {

                return Ok(foundYazar);
            }
            return NotFound();
        }
    }
}
