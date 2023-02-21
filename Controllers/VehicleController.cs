using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Decorators;
using UsedCars.Models;
using UsedCars.Services.VehicleService;

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
            var vehicleToCreate = _vehicleService.CreateVehicleAsync(vehicleDto);
            return CreatedAtRoute("GetVehicle",
                new {vehicleId = vehicleToCreate.Id },
                vehicleToCreate);
        }

        //[HttpPut("{vehicleId}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //public async Task<IActionResult> UpdateVehicleAsync(Guid vehicleId, Guid additionalEquipmentId,
        //    [FromBody] VehicleDto vehicle)
        //{

        //    if (!_vehicleRepo.VehicleExists(vehicleId))
        //    {
        //        return NotFound();
        //    }

        //    var vehicleFromRepo = await _vehicleRepo.GetVehicleAsync(vehicleId);
        //    //Upserting
        //    if (vehicleFromRepo == null)
        //    {
        //        var vehicleToAdd = _mapper.Map<Vehicle>(vehicle);
        //        vehicleToAdd.Id = vehicleId;

        //        await _vehicleRepo.AddVehicleAsync(vehicle.CategoryId,
        //               vehicle.ModelId, vehicle.MakeId, additionalEquipmentId, vehicleToAdd);

        //        _vehicleRepo.Save();

        //        var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

        //        return CreatedAtRoute("GetVehicle", new{vehicle.CategoryId,
        //               vehicle.ModelId,
        //               vehicle.MakeId,
        //               vehicleId = vehicleToReturn.Id},
        //               vehicleToReturn);
        //    }

        //    _mapper.Map(vehicle, vehicleFromRepo);

        //    _vehicleRepo.UpdateVehicle(vehicleFromRepo);

        //    _vehicleRepo.Save();

        //    return NoContent();

        //}

        //[HttpPatch("{vehicleId}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //public async Task<ActionResult> PartiallyUpdateVehicleAsync(Guid vehicleId, Guid additionalEquipmentId,
        //    [FromBody] JsonPatchDocument<VehicleDto> patchDocument)
        //{
        //    if (!_vehicleRepo.VehicleExists(vehicleId))
        //    {
        //        return NotFound();
        //    }

        //    var vehicleFromRepo = await _vehicleRepo.GetVehicleAsync(vehicleId);

        //    if (vehicleFromRepo == null)
        //    {
        //        var vehicleDto = new VehicleDto();
        //        patchDocument.ApplyTo(vehicleDto);

        //        if (!TryValidateModel(vehicleDto))
        //        {
        //            return ValidationProblem(ModelState);
        //        }

        //        var vehicleToAdd = _mapper.Map<Vehicle>(vehicleDto);
        //        vehicleToAdd.Id = vehicleId;

        //        _vehicleRepo.AddVehicleAsync(vehicleDto.CategoryId, vehicleDto.ModelId,
        //            vehicleDto.MakeId, additionalEquipmentId, vehicleToAdd);

        //        _vehicleRepo.Save();

        //        var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

        //        return CreatedAtRoute("GetVehicle", new { vehicleDto.CategoryId, vehicleDto.ModelId, vehicleDto.MakeId, vehicleId = vehicleToReturn.Id }, vehicleToReturn);
        //    }

        //    var vehicleToPatch = _mapper.Map<VehicleDto>(vehicleFromRepo);

        //    patchDocument.ApplyTo(vehicleToPatch);

        //    if (!TryValidateModel(vehicleToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(vehicleToPatch, vehicleFromRepo);

        //    _vehicleRepo.UpdateVehicle(vehicleFromRepo);

        //    _vehicleRepo.Save();

        //    return NoContent();
        //}

        [HttpDelete("{vehicleId}")]
        public async Task<ActionResult> DeleteVehicleAsync(Guid vehicleId)
        {
            var vehicleFromRepo =  _vehicleService.DeleteVehicle(vehicleId);

            return NoContent();

        }
    }
}
