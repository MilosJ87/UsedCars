using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [Route("api/vehicle")]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepo _vehicleRepo;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleRepo vehicleRepo, IMapper mapper)
        {
            _vehicleRepo = vehicleRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult<VehicleDto> CreateVehicle(Guid makeId,Guid modelId, Guid categoryId, VehicleDto vehicle)
        {
          

            var vehicleEntity = _mapper.Map<Entities.Vehicle>(vehicle);
            _vehicleRepo.AddVehicle(categoryId,makeId,modelId, vehicleEntity);
            _vehicleRepo.Save();
            

            var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleEntity);

            return Ok(vehicleToReturn);
        }
    }
}
