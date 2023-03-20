using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsedCars.API.Services;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AdditionalEquipmentController : ControllerBase
    {
        private readonly IAdditionalEquip additionalEquip;
        
        public AdditionalEquipmentController(IAdditionalEquip _additionalEquip)
        {
            additionalEquip = _additionalEquip ?? throw new ArgumentNullException(nameof(additionalEquip)); ;
        }

        [HttpGet("[controller]/[action]", Name = "getEquipmentFromApi")]
        public async Task<ActionResult<IEnumerable<AdditionalEquipmentDto>>> GetEquipmentFromApi()
        {
            var equipmentFromApi = await additionalEquip.GetAdditionalEquipment();
           
            return Ok(equipmentFromApi);
        }
        //private readonly IAdditionalEquipmentService _additionalService;

        //public AdditionalEquipmentController(IAdditionalEquipmentService additionalService)
        //{
        //    _additionalService = additionalService ?? throw new ArgumentNullException(nameof(additionalService));

        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<AdditionalEquipmentDto>> GetAdditionalEquipment()
        //{
        //    var equipmentFromRepo = _additionalService.GetEquipments();

        //    return Ok(equipmentFromRepo);
        //}

        //[HttpGet("{additionalEquipmentId}", Name = "GetAdditionalEquipment")]
        //public IActionResult GetAdditionalEquipment(Guid additionalEquipmentId)
        //{
        //    var equipment = _additionalService.GetEquipment(additionalEquipmentId);
        //    return Ok(equipment);
        //}

        //[HttpGet("{additionalEquipmentId}/vehicle")]
        //public IActionResult GetVehicleByEquipment(Guid additionalEquipmentId)
        //{
        //    var equipmentByVehicle = _additionalService.GetVehicleByEquipment(additionalEquipmentId);

        //    return Ok(equipmentByVehicle);
        //}

        //[HttpGet("{vehicleId}/additionalEquipment")]
        //public IActionResult GetAdditionalEquipmentByVehicle(Guid vehicleId)
        //{
        //    var vehicleByEquipment = _additionalService.GetEquipmentByVehicle(vehicleId);
        //    return Ok(vehicleByEquipment);
        //}
        //[HttpPost]

        //[HttpPost]
        //public ActionResult CreateAdditionalEquipment([FromBody] AdditionalEquipmentDto additionalEquipmentDtoCreate)
        //{
        //    var equipment = _additionalService.CreateEquipment(additionalEquipmentDtoCreate);

        //    return Ok(equipment);
        //}

        //[HttpDelete("{additionalEquipmentId}")]
        //public ActionResult DeleteEquipment(Guid additionalEquipmentId)
        //{
        //    var equipmentToDelete = _additionalService.DeleteEquipment(additionalEquipmentId);
        //    return Ok(equipmentToDelete);

        //}

    }
}
