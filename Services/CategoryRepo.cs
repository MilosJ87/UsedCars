using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;

namespace UsedCars.Services
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly UsedCarsContext _context;

        public CategoryRepo(UsedCarsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool CategoryExsits(Guid id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(Guid id)
        {
            return _context.Categories.Where(e => e.Id  == id).FirstOrDefault();
        }


        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        //public ICollection<Vehicle> GetVehicleCategory(Guid id)
        //{
        //    return _context.vehicleCategories.Where(e => e.CategoryId == id).Select(c => c.Vehicle).ToList();
        //}

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public void UpdateCategory(Category category)
        {
            
        }


    }
}
