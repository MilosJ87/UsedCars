using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IVehicleRepo
    {
        void AddVehicle(Guid categoryId, Guid modelId, Guid makeId, Vehicle vehicle);
        bool VehicleExists(Guid categoryId);
        void DeleteVehicle(Vehicle vehicle);
        void Dispose();
        Vehicle GetVehicle(Guid categoryId, Guid modelId, Guid makeId, Guid vehicleId);
        ICollection<Vehicle> GetVehicles();
        bool Save();
        void UpdateVehicle(Vehicle vehicle);
    }
}