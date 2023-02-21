using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository.Category;

namespace UsedCars.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }
        [HttpGet("{categoryId}", Name="GetCategory")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var category = await _categoryRepo.GetById(categoryId);
            if (category==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
           

            var categoryEntity = _mapper.Map<Category>(categoryCreate);
            _categoryRepo.Insert(categoryEntity);
            _categoryRepo.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return Ok(categoryToReturn);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody] UpdateCategoryDto category)
        {
            if (!_categoryRepo.CategoryExsits(categoryId))
            {
                return NotFound();
            }

            var categoryFromRepo = _categoryRepo.GetById(categoryId);

            if (categoryFromRepo == null)
            {
                var categoryToAdd = _mapper.Map<Category>(category);
                categoryToAdd.Id = categoryId;

                _categoryRepo.Insert(categoryToAdd);

                _categoryRepo.Save();

                var categoryToReturn = (_mapper.Map<CategoryDto>(categoryToAdd));

                return CreatedAtRoute("GetCategory", new { categoryId = categoryToReturn.Id }, categoryToReturn);
               
            }

            _mapper.Map(category, categoryFromRepo);

            _categoryRepo.Update(await categoryFromRepo);

            _categoryRepo.Save();

            return NoContent();
            
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(Guid categoryId)
        {
            var categoryFromRepo = _categoryRepo.GetById(categoryId);

            if (categoryFromRepo==null)
            {
                return NotFound();
            }

            _categoryRepo.Delete(categoryFromRepo);
            _categoryRepo.Save();

            return NoContent();

        }




     


    }
}
