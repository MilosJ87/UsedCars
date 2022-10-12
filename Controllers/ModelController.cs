using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [Route("api/model")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelRepo _modelRepo;

        private readonly IMapper _mapper;

        public ModelController(IModelRepo modelRepo, IMapper mapper)
        {
            _modelRepo = modelRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetModels()
        {
            var models = _mapper.Map<List<ModelDto>>(_modelRepo.GetModels());
            return Ok(models);
        }

        [HttpGet("{modelId}", Name = "GetModel")]
        public IActionResult GetModel(Guid modelId)
        {
            var model = _modelRepo.GetModel(modelId);

            return Ok(_mapper.Map<ModelDto>(model));
        }

        [HttpPost]
        public IActionResult CreateModel([FromBody] ModelDto modelCreate)
        {
            var modelEntity = _mapper.Map<Model>(modelCreate);
            _modelRepo.CreateModel(modelEntity);

            var modelToReturn = _mapper.Map<ModelDto>(modelEntity);
            return Ok(modelToReturn);
        }

        [HttpPut("{modelId}")]
        public IActionResult UpdateModel(Guid modelId, [FromBody] ModelDto modelDtoUpdate)
        {
            if (!_modelRepo.ModelExists(modelId))
            {
                return NotFound();
            }

            var modelFromRepo = _modelRepo.GetModel(modelId);

            _mapper.Map(modelDtoUpdate, modelFromRepo);

            _modelRepo.UpdateModel(modelFromRepo);

            _modelRepo.Save();

            return NoContent();
        }

        [HttpDelete("{deleteId}")]
        public ActionResult DeleteModel(Guid modelId)
        {
            var modelFromRepo = _modelRepo.GetModel(modelId);

            if (modelFromRepo == null)
            {
                return NotFound();
            }
            _modelRepo.DeleteModel(modelFromRepo);
            _modelRepo.Save();

            return NoContent();

        }
                
    }
}
