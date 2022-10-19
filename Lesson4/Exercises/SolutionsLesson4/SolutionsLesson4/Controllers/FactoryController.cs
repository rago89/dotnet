using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolutionsLesson4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> HelloFrom()
        {
            return $"Hello from {nameof(UserController)}";
        }

        [HttpPost]
        [Route("[action]/{factoryName}")]
        public IActionResult Name([FromRoute] string factoryName)
        {
            return Ok($"This factory is called {factoryName}");
        }
    }
}
