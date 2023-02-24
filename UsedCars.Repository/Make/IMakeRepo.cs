using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public interface IMakeRepo : IGenericRepository<Entities.Make>
    {
        void Dispose();
        bool MakeExists(Guid id);
    }
}