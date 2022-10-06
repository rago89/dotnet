using lesson4_exercice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Account;
using Microsoft.VisualStudio.Services.Licensing;
using System.Globalization;

namespace lesson4_exercice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private DBVehicle _db;
        public VehicleController(DBVehicle db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Vehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid && vehicle.Owner is not null)
            {
                if (vehicle.Owner.Age < 18)
                {
                    BadRequest($"Owner age is under 18 age: {vehicle.Owner.Age}");
                }

                if (vehicle.Licence == 0)
                {
                    BadRequest($"License is not valid license: {vehicle.Licence}");
                }

                Vehicle newVehicle = new(vehicle.Licence, vehicle.Model, vehicle.Owner);
                _db.Vehicles.Add(newVehicle);

                VehicleDto vehicleDto = new(newVehicle.Id, newVehicle.Licence, newVehicle.Model);

                return Ok($"Vehicle with id:{vehicleDto.Id} model: {vehicleDto.Model} and license: {vehicleDto.Licence} was added");
            }

            return BadRequest("Invalid input values");
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            var vehicles = new List<VehicleDto>();
            _db.Vehicles.ForEach(vehicle => vehicles.Add(new VehicleDto(vehicle.Id, vehicle.Licence, vehicle.Model)));
            return Ok(vehicles);
        }

        [HttpGet]
        [Route(template: "{id}")]
        public IActionResult GetVehicle(string id)
        {
            var vehicleFound = _db.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
            if (vehicleFound != null)
            {
                return Ok(new VehicleDto(vehicleFound.Id, vehicleFound.Licence, vehicleFound.Model));
            }
            return NotFound($"Vehicle with the given id: {id} not found");
        }
    }
}
