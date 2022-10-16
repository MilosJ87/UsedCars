using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IVehicleRepo
    {
        Task AddVehicleAsync(Guid categoryId, Guid modelId, Guid makeId, Guid additionalEquipmentId, Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
        void Dispose();
        Task<Vehicle> GetVehicleAsync(Guid vehicleId);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<bool> Save();
        Task UpdateVehicle(Vehicle vehicle);
        bool VehicleExists(Guid vehicleId);
    }
}