using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository.AdditionalEquipment
{
    public interface IAdditionalService : IGenericRepository<Entities.AdditionalEquipment>
    {
        bool AdditionalEquipmentExists(Guid id);
        void CreateVehicleForEquipment(Guid additionalEquipmentId, Vehicle vehicle);
        ICollection<Entities.AdditionalEquipment> GetEquipmentByVehicle(Guid vehicleId);
        ICollection<Vehicle> GetVehicleByEquipment(Guid additionalEquipmentId);
    }
}