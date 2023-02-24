using UsedCars.GenericRepository;

namespace UsedCars.Services
{
    public interface IMakeRepo : IGenericRepository<Entities.Make>
    {
        void Dispose();
        bool MakeExists(Guid id);
    }
}