using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface ICategoryRepo
    {
        bool CategoryExsits(Guid id);
        bool CreateCategory(Category category);
        bool DeleteCategory(Category category);
        ICollection<Category> GetCategories();
        Category GetCategory(Guid Id);
        bool Save();
        void UpdateCategory(Category category);
    }
}