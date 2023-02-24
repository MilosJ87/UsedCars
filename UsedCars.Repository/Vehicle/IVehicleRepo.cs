using UsedCars.GenericRepository;

namespace UsedCars.Services
{
    public interface IVehicleRepo : IGenericRepository<Entities.Vehicle>
    {
        void Dispose();
        bool VehicleExists(Guid vehicleId);
    }
}