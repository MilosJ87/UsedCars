using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Services
{
    public interface IModelRepo : IGenericRepository<Model>
    {
        void Dispose();
        bool ModelExists(Guid id);
    }
}