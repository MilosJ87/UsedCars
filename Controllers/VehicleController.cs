using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Decorators;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepo _vehicleRepo;
        private readonly IMapper _mapper;
        public VehicleController(IVehicleRepo vehicleRepo, IMapper mapper)
        {
            _vehicleRepo = vehicleRepo ?? throw new ArgumentNullException(nameof(vehicleRepo));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
      //  [Authorize]
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehiclesAsync()
        {
            var claims = User.Claims;
            var vehiclesFromRepo = await _vehicleRepo.GetVehiclesAsync();

            return Ok(_mapper.Map<IEnumerable<VehicleDto>>(vehiclesFromRepo));
        }

        [HttpGet("{vehicleId}", Name = "GetVehicle")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<VehicleDto>> GetVehicleAsync(Guid vehicleId)
        {
            var vehicleFromRepo = await _vehicleRepo.GetVehicleAsync(vehicleId);

            return Ok(_mapper.Map<VehicleDto>(vehicleFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult<VehicleDto>> CreateVehicleAsync(Guid categoryId,
           Guid modelId, Guid makeId, Guid additionalEquipmentId, [FromBody] VehicleDto vehicle)
        {
            var vehicleEntity = _mapper.Map<Entities.Vehicle>(vehicle);
            await _vehicleRepo.AddVehicleAsync(categoryId,
                modelId, makeId, additionalEquipmentId, vehicleEntity);
            await _vehicleRepo.Save();

            var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleEntity);

            return CreatedAtRoute("GetVehicle",
                new { categoryId, modelId, makeId, vehicleId = vehicleToReturn.Id },
                vehicleToReturn); 
        }

        [HttpPut("{vehicleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateVehicleAsync(Guid vehicleId, Guid additionalEquipmentId,
            [FromBody] VehicleDto vehicle)
        {

            if (!_vehicleRepo.VehicleExists(vehicleId))
            {
                return NotFound();
            }

            var vehicleFromRepo = await _vehicleRepo.GetVehicleAsync(vehicleId);
            //Upserting
            if (vehicleFromRepo == null)
            {
                var vehicleToAdd = _mapper.Map<Vehicle>(vehicle);
                vehicleToAdd.Id = vehicleId;

                await _vehicleRepo.AddVehicleAsync(vehicle.CategoryId,
                       vehicle.ModelId, vehicle.MakeId, additionalEquipmentId, vehicleToAdd);

                _vehicleRepo.Save();

                var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

                return CreatedAtRoute("GetVehicle", new{vehicle.CategoryId,
                       vehicle.ModelId,
                       vehicle.MakeId,
                       vehicleId = vehicleToReturn.Id},
                       vehicleToReturn);
            }

            _mapper.Map(vehicle, vehicleFromRepo);

            _vehicleRepo.UpdateVehicle(vehicleFromRepo);

            _vehicleRepo.Save();

            return NoContent();

        }

        [HttpPatch("{vehicleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PartiallyUpdateVehicleAsync(Guid vehicleId, Guid additionalEquipmentId,
            [FromBody] JsonPatchDocument<VehicleDto> patchDocument)
        {
            if (!_vehicleRepo.VehicleExists(vehicleId))
            {
                return NotFound();
            }

            var vehicleFromRepo = await _vehicleRepo.GetVehicleAsync(vehicleId);

            if (vehicleFromRepo == null)
            {
                var vehicleDto = new VehicleDto();
                patchDocument.ApplyTo(vehicleDto);

                if (!TryValidateModel(vehicleDto))
                {
                    return ValidationProblem(ModelState);
                }

                var vehicleToAdd = _mapper.Map<Vehicle>(vehicleDto);
                vehicleToAdd.Id = vehicleId;

                _vehicleRepo.AddVehicleAsync(vehicleDto.CategoryId, vehicleDto.ModelId,
                    vehicleDto.MakeId, additionalEquipmentId, vehicleToAdd);

                _vehicleRepo.Save();

                var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

                return CreatedAtRoute("GetVehicle", new { vehicleDto.CategoryId, vehicleDto.ModelId, vehicleDto.MakeId, vehicleId = vehicleToReturn.Id }, vehicleToReturn);
            }

            var vehicleToPatch = _mapper.Map<VehicleDto>(vehicleFromRepo);

            patchDocument.ApplyTo(vehicleToPatch);

            if (!TryValidateModel(vehicleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(vehicleToPatch, vehicleFromRepo);

            _vehicleRepo.UpdateVehicle(vehicleFromRepo);

            _vehicleRepo.Save();

            return NoContent();
        }
        
        [HttpDelete("{vehicleId}")]
        public async Task<ActionResult> DeleteVehicleAsync(Guid vehicleId)
        {
            var vehicleFromRepo = await _vehicleRepo.GetVehicleAsync(vehicleId);

            if (vehicleFromRepo == null)
            {
                return NotFound();
            }

            _vehicleRepo.DeleteVehicle(vehicleFromRepo);
            _vehicleRepo.Save();

            return NoContent();

        }
    }
}
