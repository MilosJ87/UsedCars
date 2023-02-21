using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository.AdditionalEquipment;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/additionalequipment")]
    public class AdditionalEquipmentController : ControllerBase
    {
        private readonly IAdditionalEquipmentRepo _additionalEquipmentRepo;

        private readonly IMapper _mapper;

        public AdditionalEquipmentController(IAdditionalEquipmentRepo additionalEquipmentRepo, IMapper mapper)
        {
            _additionalEquipmentRepo = additionalEquipmentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdditionalEquipmentDto>> GetAdditionalEquipment()
        {
            var equipmentFromRepo = _additionalEquipmentRepo.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<AdditionalEquipmentDto>>(equipmentFromRepo));
        }

        [HttpGet("{additionalEquipmentId}", Name = "GetAdditionalEquipment")]
        public IActionResult GetAdditionalEquipment(Guid additionalEquipmentId)
        {
            var equipment = _additionalEquipmentRepo.GetById(additionalEquipmentId);
            return Ok(equipment);
        }

        [HttpGet("{additionalEquipmentId}/vehicle")]
        public IActionResult GetVehicleByEquipment(Guid additionalEquipmentId)
        {
            if (!_additionalEquipmentRepo.AdditionalEquipmentExists(additionalEquipmentId))
            {
                return NotFound();
            }

            var equipment = _mapper.Map<List<VehicleDto>>(
                _additionalEquipmentRepo.GetVehicleByEquipment
                (additionalEquipmentId));
            return Ok(equipment);
        }

        [HttpGet("{vehicleId}/additionalEquipment")]
        public IActionResult GetAdditionalEquipmentByVehicle(Guid vehicleId)
        {
            var vehicle = _mapper.Map<List<AdditionalEquipmentDto>>(
                _additionalEquipmentRepo.
                GetEquipmentByVehicle(vehicleId));
            return Ok(vehicle);
        }

        [HttpPost]
        public ActionResult CreateAdditionalEquipment([FromBody] AdditionalEquipmentDto additionalEquipmentDtoCreate)
        {
            var additionalEquipmentEntity = _mapper.Map<AdditionalEquipment>(additionalEquipmentDtoCreate);
            _additionalEquipmentRepo.Insert(additionalEquipmentEntity);
            _additionalEquipmentRepo.Save();

            var equipmentToReturn = _mapper.Map<AdditionalEquipmentDto>(additionalEquipmentEntity);

            return Ok(equipmentToReturn);

        }

        [HttpPut("{additionalequipmentId}")]
        public IActionResult UpdateEquipment(Guid additionalEquipmentId,
            [FromBody] UpdateAdditionalEquipment updateAdditionalEquipment)
        {
            if (!_additionalEquipmentRepo.AdditionalEquipmentExists(additionalEquipmentId))
            {
                return NotFound();
            }

            var equipmentFromRepo = _additionalEquipmentRepo.GetById(additionalEquipmentId);

            _mapper.Map(updateAdditionalEquipment, equipmentFromRepo);
            _additionalEquipmentRepo.Update(equipmentFromRepo);
            _additionalEquipmentRepo.Save();

            return NoContent();
        }

        [HttpDelete("{additionalEquipmentId}")]
        public ActionResult DeleteEquipment(Guid additionalEquipmentId)
        {
            var equipmentFromRepo = _additionalEquipmentRepo.GetById(additionalEquipmentId);

            if (equipmentFromRepo == null)
            {
                return NotFound();
            }

            _additionalEquipmentRepo.Delete(equipmentFromRepo);
            _additionalEquipmentRepo.Save();

            return NoContent();

        }
    }
}
