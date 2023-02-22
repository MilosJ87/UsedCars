using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Services;
using UsedCars.Services.MakeService;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/make")]
    public class MakeController : ControllerBase
    {
        private readonly IMakeService _makeService;
        

        public MakeController(IMakeService makeService)
        {
            _makeService = makeService ?? throw new ArgumentNullException(nameof(makeService));
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<MakeDto>> GetMakes()
        {
            var makesFromRepo = _makeService.GetMakes();
            return Ok(makesFromRepo);
        }

        [HttpGet("{makeId}", Name = "GetMake")]
        public IActionResult GetMake(Guid makeId)
        {
            var make = _makeService.GetMake(makeId);
            return Ok(make);
        }

        [HttpPost]
        public ActionResult CreateMake([FromBody] MakeDto createMake)
        {
            var makeToReturn = _makeService.CreateMake(createMake);
            
            return Ok(makeToReturn);
            
        }

       
        [HttpDelete("{makeId}")]
        public ActionResult DeleteMake(Guid makeId)
        {
            var makeFromRepo = _makeService.DeleteMake(makeId);
           
           return NoContent();
        }

    }
}
