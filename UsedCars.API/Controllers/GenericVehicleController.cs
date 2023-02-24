using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;
using UsedCars.Models;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class GenericVehicleController : ControllerBase
    {
        private IGenericRepository<Vehicle> _repository;
        private IMapper _mapper;

        public GenericVehicleController(IGenericRepository<Vehicle> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet]
        [Route("GetVehiclesById/{vehicleId}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(Guid id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleDto vehicleDto)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(vehicleDto);
            _repository.Insert(vehicleEntity);
            _repository.Save();
            return Ok(vehicleEntity);
        }

        [HttpPut]
        [Route("{vehicleId}")]

        public async Task<IActionResult> UpdateVehicleAsync(Guid vehicleId,[FromBody]VehicleDto vehicle)
        {
            var vehicleFromRepo = await _repository.GetById(vehicleId);

            _mapper.Map(vehicle, vehicleFromRepo);
            _repository.Update(vehicleFromRepo);
            _repository.Save();

            return NoContent();
        }
    }
}
