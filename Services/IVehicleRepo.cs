using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IVehicleRepo
    {
        void AddVehicle(Guid makeId, Guid categoryId, Guid modelId, Vehicle vehicle);
        bool categoryExists(Guid categoryId);
        ICollection<Vehicle> GetVehicles();
        bool Save();
    }
}