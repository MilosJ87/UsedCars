using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository;
using UsedCars.Services;

namespace UsedCars.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categoriesToReturn = _categoryService.GetCategories();
            return Ok(categoriesToReturn);
        }
        [HttpGet("{categoryId}", Name="GetCategory")]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var category = await _categoryService.GetCategory(categoryId);
            if (category==null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            var categoryToReturn = _categoryService.CreateCategory(categoryCreate);
            return Ok(categoryToReturn);
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(Guid categoryId)
        {
            var categoryFromRepo = _categoryService.DeleteCategory(categoryId);
            
            if (categoryFromRepo==null)
            {
                return NotFound();
            }
                      
            return NoContent();
            
        }
        
    }
}
