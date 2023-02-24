using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public interface IVehicleRepo : IGenericRepository<Entities.Vehicle>
    {
        void Dispose();
        bool VehicleExists(Guid vehicleId);
    }
}