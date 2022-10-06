using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson4_exercice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Vehicle() 
        {
            return Ok("Hello from Vehicle controller");
        }
    }
}
