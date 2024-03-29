﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [ApiController]
    [Route("api/make")]
    public class MakeController : ControllerBase
    {
        private readonly IMakeRepo _makeRepo;
        private readonly IMapper _mapper;

        public MakeController(IMakeRepo makeRepo, IMapper mapper)
        {
            _makeRepo = makeRepo ?? throw new ArgumentNullException(nameof(makeRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MakeDto>> GetMakes()
        {
            var makesFromRepo = _makeRepo.GetMakes();
            return Ok(_mapper.Map<IEnumerable<MakeDto>>(makesFromRepo));
        }

        [HttpGet("{makeId}", Name = "GetMake")]
        public IActionResult GetMake(Guid makeId)
        {
            var make = _makeRepo.GetMake(makeId);
            return Ok(make);
        }

        [HttpPost]
        public ActionResult CreateMake([FromBody] MakeDto createMake)
        {
            var makeEntity = _mapper.Map<Make>(createMake);
            _makeRepo.CreateMake(makeEntity);
            _makeRepo.Save();

            var makeToReturn = _mapper.Map<MakeDto>(makeEntity);
            
            return Ok(makeToReturn);
            
        }

        [HttpPut("{makeId}")]
        public IActionResult UpdateMake(Guid makeId, [FromBody] UpdateMakeDto updateMakeDto)
        {
            if (!_makeRepo.MakeExists(makeId))
            {
                return NotFound();
            }

            var makeFromRepo = _makeRepo.GetMake(makeId);

            _mapper.Map(updateMakeDto, makeFromRepo);
            _makeRepo.UpdateMake(makeFromRepo);
            _makeRepo.Save();

            return NoContent();

        }

        [HttpDelete("{makeId}")]
        public ActionResult DeleteMake(Guid makeId)
        {
            var makeFromRepo = _makeRepo.GetMake(makeId);
           
            if (makeFromRepo == null)
            {
                return NotFound();
            }
            _makeRepo.DeleteMake(makeFromRepo);
            _makeRepo.Save();

            return NoContent();
        }

    }
}
