using Microsoft.AspNetCore.Mvc;
using SolutionsLesson4.Model;

namespace SolutionsLesson4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> _users = new()
        {
            new User("Matilda", 21, "Ghent", Gender.Female),
            new User("Jack", 30, "Antwerp", Gender.Male),
            new User("Josephine", 18, "Kortrijk", Gender.Other),
        };


        [HttpGet]
        public ActionResult<string> HelloFrom()
        {
            return $"Hello from {nameof(UserController)}";
        }

        [HttpPost]
        [Route("{age}")]
        public IActionResult PostAge(int age)
        {
            if (age < 18)
            {
                return BadRequest("Too young");
            }

            return Ok("Perfect");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult MyNameIs([FromBody] string name)
        {
            return Ok($"Hello my name is {name}");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddUser(User user)
        {
            return Ok($"Hi my name is {user.Name}, I'm {user.Age} and I'm from {user.Address}. My gender is {user.Gender}.");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUserFromList(string name)
        {
            var userFound = _users.FirstOrDefault(x => x.Name == name);
            if (userFound == null)
                return NotFound($"No user found with name {name}");
            return Ok(userFound);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddUserToList(User user)
        {
            _users.Add(user);
            return Ok(_users);
        }
    }
}
