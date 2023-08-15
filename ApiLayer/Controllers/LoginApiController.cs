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

        [HttpPost]
        public async Task<IActionResult> Index(Yazar yazar)
        {
            var foundYazar = yazarManager.GetByLogin(yazar.Mail, yazar.Sifre);

            if (foundYazar != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, yazar.Mail),
                    new Claim("YazarId", foundYazar.YazarId.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return Ok();
            }
            return NotFound();
        }
    }
}
