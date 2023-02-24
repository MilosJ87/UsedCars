using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository.Category;
using UsedCars.Services.ModelService;

namespace UsedCars.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoriesToReturn
                = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesToReturn;
        }

        public async Task<CategoryDto> GetCategory(Guid modelId)
        {
            var category = await _categoryRepo.GetById(modelId);
            var categoryToReturn = _mapper.Map<CategoryDto>(category);
            return categoryToReturn;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            var categoryToCreate = _mapper.Map<Category>(categoryDto);
            _categoryRepo.Insert(categoryToCreate);
            _categoryRepo.Save();
            var categoryToReturn = _mapper.Map<CategoryDto>(categoryToCreate);
            return categoryToReturn;

        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var categoryToDelete = _categoryRepo.GetById(categoryId);
            var deleteCategory = _categoryRepo.Delete(categoryToDelete);
            _categoryRepo.Save();

        }
    }
}
