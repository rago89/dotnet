using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionsLesson4.Model;

namespace SolutionsLesson4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private List<Vehicle> _vehicles = new()
        {
            new Vehicle("1-AAA-236", "Tesla"),
            new Vehicle("2-ABC-456", "Volvo", new User("Josh", 50, "Brussels", Gender.Male))
        };

        [HttpGet]
        public ActionResult<string> HelloFrom()
        {
            return $"Hello from {nameof(UserController)}";
        }

        [HttpPost]
        [Route("{wheels}")]
        public IActionResult PostWheels(int wheels)
        {
            if (wheels < 4)
            {
                return BadRequest("Short on wheels");
            }

            return Ok("Perfect");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetVehicleFromList(string licensePlate)
        {
            var foundVehicle = _vehicles.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (foundVehicle == null)
                return NotFound($"No vehicle found with license plate {licensePlate}");

            return Ok(foundVehicle);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddVehicleToList(VehicleDto vehicle)
        {
            return Ok(vehicle.FromDto());
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddUserToVehicleInList(string licensePlate, User user)
        {
            var foundVehicle = _vehicles.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (foundVehicle == null)
                return NotFound($"No vehicle found with license plate {licensePlate}");
            foundVehicle.Owner = user;
            
            return Ok(foundVehicle);
        }
    }
}
