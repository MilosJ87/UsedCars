using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<VehicleDto>> GetVehicles()
        {

            var vehiclesFromRepo = _vehicleRepo.GetVehicles();

            return Ok(_mapper.Map<IEnumerable<VehicleDto>>(vehiclesFromRepo));
        }

        [HttpGet("{vehicleId}", Name ="GetVehicle")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<VehicleDto> GetVehicle(Guid categoryId, Guid makeId, Guid modelId, Guid vehicleId,Guid additionalEquipmentId)
        {
            var vehicleFromRepo = _vehicleRepo.GetVehicle(categoryId, makeId, modelId,additionalEquipmentId, vehicleId);

            return Ok(_mapper.Map<VehicleDto>(vehicleFromRepo));
        }

       



        [HttpPost]
       
        public ActionResult<VehicleDto> CreateVehicle(Guid categoryId, Guid modelId, Guid makeId, Guid additionalEquipmentId, VehicleDto vehicle)
        {
          

            var vehicleEntity = _mapper.Map<Entities.Vehicle>(vehicle);
            _vehicleRepo.AddVehicle(categoryId, modelId, makeId,additionalEquipmentId, vehicleEntity);
            _vehicleRepo.Save();
            

            var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleEntity);

            return CreatedAtRoute("GetVehicle", new { categoryId, modelId, makeId,additionalEquipmentId, vehicleId = vehicleToReturn.Id }, vehicleToReturn); ;
        }

        [HttpPut("{vehicleId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateVehicle(Guid categoryId, Guid modelId, Guid makeId, Guid vehicleId,Guid additionalEquipmentId, [FromBody] VehicleDto vehicle)
        {
            
                if (!_vehicleRepo.VehicleExists(vehicleId))
                {
                    return NotFound();
                }

                var vehicleFromRepo = _vehicleRepo.GetVehicle(categoryId, modelId, makeId, additionalEquipmentId, vehicleId);
                //Upserting
                if (vehicleFromRepo==null)
                {
                    var vehicleToAdd = _mapper.Map<Vehicle>(vehicle);
                    vehicleToAdd.Id = vehicleId;

                    _vehicleRepo.AddVehicle(categoryId, modelId, makeId, additionalEquipmentId, vehicleToAdd);

                    _vehicleRepo.Save();

                    var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

                    return CreatedAtRoute("GetVehicle", new { categoryId,modelId,makeId, additionalEquipmentId, vehicleId = vehicleToReturn.Id }, vehicleToReturn);
                }

                _mapper.Map(vehicle, vehicleFromRepo);

                _vehicleRepo.UpdateVehicle(vehicleFromRepo);

                _vehicleRepo.Save();

                return NoContent();
            

           
        }
      [HttpPatch("{vehicleId}")]
      [ProducesResponseType(204)]
      [ProducesResponseType(400)]
      public ActionResult PartiallyUpdateVehicle(Guid categoryId, Guid modelId, Guid makeId,Guid additionalEquipmentId, Guid vehicleId,JsonPatchDocument<VehicleDto> patchDocument)
        {
            if (!_vehicleRepo.VehicleExists(vehicleId))
            {
                return NotFound();
            }

            var vehicleFromRepo = _vehicleRepo.GetVehicle(categoryId, modelId, makeId,additionalEquipmentId, vehicleId);

            if (vehicleFromRepo==null)
            {
                var vehicleDto = new VehicleDto();
                patchDocument.ApplyTo(vehicleDto);

                if (!TryValidateModel(vehicleDto))
                {
                    return ValidationProblem(ModelState);
                }

                var vehicleToAdd = _mapper.Map<Vehicle>(vehicleDto);
                vehicleToAdd.Id = vehicleId;

                _vehicleRepo.AddVehicle( categoryId, modelId, makeId, additionalEquipmentId, vehicleToAdd);

                _vehicleRepo.Save();

                var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

                return CreatedAtRoute("GetVehicle", new { categoryId, modelId, makeId, vehicleId = vehicleToReturn.Id }, vehicleToReturn);
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
        public ActionResult DeleteVehicle(Guid categoryId, Guid modelId, Guid makeId,Guid additionalEquipmentId, Guid vehicleId)
        {
            var vehicleFromRepo = _vehicleRepo.GetVehicle(categoryId, modelId, makeId, additionalEquipmentId, vehicleId);

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
