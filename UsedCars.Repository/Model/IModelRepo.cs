using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public interface IModelRepo : IGenericRepository<Model>
    {
        void Dispose();
        bool ModelExists(Guid id);
    }
}