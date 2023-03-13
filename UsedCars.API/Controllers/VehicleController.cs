using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UsedCars.Decorators;
using UsedCars.Models;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
        }
      //  [Authorize]
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult> GetVehiclesAsync()
        {
            var claims = User.Claims;
            var vehiclesToReturn = await _vehicleService.GetAllVehicles();
            return Ok(vehiclesToReturn);
        }

        [HttpGet("{vehicleId}", Name = "GetVehicle")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> GetVehicleAsync(Guid vehicleId)
        {
            var vehicleFromRepo = await _vehicleService.GetVehicle(vehicleId);

            return Ok(vehicleFromRepo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicleAsync([FromBody] VehicleDto vehicleDto)
        {
            var vehicleToCreate = await _vehicleService.CreateVehicleAsync(vehicleDto);
            return CreatedAtRoute("GetVehicle",
                new {vehicleId = vehicleToCreate.Id },
                vehicleToCreate);
        }

        [HttpPut("{vehicleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateVehicleAsync(Guid vehicleId, [FromBody] VehicleDto vehicle)
        {
            if (vehicle == null || vehicle.Id != vehicleId)
            {
                return BadRequest();
            }

            var updatedVehicle = await _vehicleService.UpdateVehicle(vehicle);

            if (updatedVehicle == null)
            {
                return BadRequest();
            }

            return NoContent();

        }

        [HttpPatch("{vehicleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PartiallyUpdateVehicleAsync(Guid vehicleId,
            [FromBody] JsonPatchDocument<VehicleDto> patchDocument)
        {
           await _vehicleService.PatchVehicle(vehicleId,patchDocument);


            return NoContent();
        }

        [HttpDelete("{vehicleId}")]
        public async Task<ActionResult> DeleteVehicleAsync(Guid vehicleId)
        {
            var vehicleFromRepo = _vehicleService.DeleteVehicle(vehicleId);
            
            return NoContent();

        }

      
       
    }
}
