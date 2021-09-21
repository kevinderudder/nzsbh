using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NZSBH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController:ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Publisher>), 200)]
        [ProducesResponseType(404)]
        [ResponseCache(Duration = 120)]
        public IActionResult Get() {
            var publishers = new List<Publisher>() {
                new Publisher(){ 
                    Id = Guid.NewGuid(),
                    Title ="Het ei van jens"
                }
            };
            return Ok(publishers);
        }
    }
}
