using UsedCars.Models;

namespace UsedCars.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
        Task DeleteCategory(Guid categoryId);
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(Guid modelId);
    }
}