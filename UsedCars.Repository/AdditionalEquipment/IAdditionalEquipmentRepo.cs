using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public interface IAdditionalEquipmentRepo : IGenericRepository<AdditionalEquipment>
    {
        bool AdditionalEquipmentExists(Guid id);
        void CreateVehicleForEquipment(Guid additionalEquipmentId, Vehicle vehicle);
        ICollection<AdditionalEquipment> GetEquipmentByVehicle(Guid vehicleId);
        ICollection<Vehicle> GetVehicleByEquipment(Guid additionalEquipmentId);
    }
}