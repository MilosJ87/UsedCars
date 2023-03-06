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
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        [HttpGet]
        public async Task< ActionResult> GetModels()
        {
            var modelsToReturn = await _modelService.GetModels();

            return Ok(modelsToReturn);
        }

        [HttpGet("{modelId}", Name = "GetModel")]
        public async Task<IActionResult> GetModel(Guid modelId)
        {
           var modelToReturn = await _modelService.GetModel(modelId);
            return Ok(modelToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<MakeDto>> CreateModel([FromBody] MakeDto modelCreate)
        {
            var modelToReturn = await _modelService.CreateModel(modelCreate);

            return Ok(modelToReturn);
        }



        [HttpDelete("{deleteId}")]
        public ActionResult DeleteModel(Guid modelId)
        {
            var modelToDelete = _modelService.DeleteModel(modelId);
            return NoContent();

        }

    }
}
