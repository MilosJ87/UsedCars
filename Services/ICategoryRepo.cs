using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface ICategoryRepo
    {

        bool CategoryExsits(Guid id);
        bool CreateCategory(Category category);
        bool DeleteCategory(Category category);
        ICollection<Category> GetCategories();
        Category GetCategory(Guid id);
        ICollection<Vehicle> GetVehicleCategory(Guid id);
        bool Save();
        bool UpdateCategory(Category category);
    }
}