using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson4_exercice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        [HttpGet]
        [Route(template:"{name}")]
        public IActionResult Factory(string name) 
        {
            return Ok($"pathName {name}");
        }
    }
}
