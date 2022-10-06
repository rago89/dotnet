using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lesson4_exercice.Models;
using lesson4_exercice.Dto;
using Newtonsoft.Json.Linq;
using lesson4_exercice.Exceptions;

namespace lesson4_exercice.Controllers
{
    [TypeFilter(typeof(UserExceptionFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DBUser _db;

        public UserController(DBUser db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult SetAge(int age)
        {
            if (age < 18)
            {
                return BadRequest("Age is less than 18");
            }
            return Ok($"Your age is: {age}");
        }

        [HttpPost]
        [Route(template: "{name}")]
        public IActionResult SetName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Name is empty");
            }

            return Ok($"Your name is: {name}");
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {

                User newUser = new(user.Name, user.Age, user.Address, user.Gender, user.Email, user.Password);

                _db.Users.Add(newUser);

                UserDto userDto = new(newUser.Id, newUser.Name, newUser.Age, newUser.Address, newUser.Gender);

                string userFormatted = $@"
                            id: {userDto.Id},
                            name: {userDto.Name},
                            age: {userDto.Age},
                            address: {userDto.Address},
                            gender: {userDto.Gender} 
                            ";

                return Ok(userFormatted);
            }

            return BadRequest("Invalid input values");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<UserDto> usersDto = new List<UserDto>();

            _db.Users.ForEach(user => usersDto.Add(new UserDto(user.Id, user.Name, user.Age, user.Address, user.Gender)));

            return Ok(usersDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(string id)
        {

            foreach (User user in _db.Users)
            {
                if (!(user == null) && user.Id == id)
                {
                    var u = new UserDto(user.Id, user.Name, user.Age, user.Address, user.Gender);

                    return Ok(u);
                }
            }
            return NotFound(String.Format("User with the given Id: {0} not found", id));
        }
    }
}
