using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository.Category
{
    public interface ICategoryRepo : IGenericRepository<Entities.Category>
    {
        bool CategoryExsits(Guid id);
   
    }
}