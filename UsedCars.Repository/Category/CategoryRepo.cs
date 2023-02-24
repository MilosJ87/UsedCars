using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository.Category
{
    public class CategoryRepo : GenericRepository<Entities.Category>, ICategoryRepo
    {
        public CategoryRepo(UsedCarsContext context) : base(context)
        {
        }

        public bool CategoryExsits(Guid id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

    }
}
