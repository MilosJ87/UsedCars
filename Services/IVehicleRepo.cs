using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IVehicleRepo
    {
        Task AddVehicle(Guid categoryId, Guid modelId, Guid makeId, Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
        void Dispose();
        Task<Vehicle> GetVehicle(Guid categoryId, Guid modelId, Guid makeId, Guid vehicleId);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<bool> Save();
        Task UpdateVehicle(Vehicle vehicle);
        bool VehicleExists(Guid vehicleId);
    }
}