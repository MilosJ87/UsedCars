using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public interface ICategoryRepo : IGenericRepository<Entities.Category>
    {
        bool CategoryExsits(Guid id);
   
    }
}