using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public interface IVehicleRepo : IGenericRepository<Entities.Vehicle>
    {      
        bool VehicleExists(Guid vehicleId);
    }
}