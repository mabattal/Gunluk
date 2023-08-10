﻿using ApiLayer.DataAccessLayer;
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
    }
}
