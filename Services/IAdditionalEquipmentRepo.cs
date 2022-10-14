using UsedCars.Entities;

namespace UsedCars.Services
{
    public interface IAdditionalEquipmentRepo
    {
        bool AdditionalEquipmentExists(Guid id);
        bool CreateAdditionalEquipment(AdditionalEquipment additionalEquipment);
        bool DeleteEquipment(AdditionalEquipment additionalEquipment);
        void Dispose();
        AdditionalEquipment GetAdditionalEquipment(Guid id);
        ICollection<AdditionalEquipment> GetAdditionalEquipments();
        ICollection<AdditionalEquipment> GetEquipmentByVehicle(Guid vehicleId);
        ICollection<Vehicle> GetVehicleByEquipment(Guid additionalEquipmentId);
        bool Save();
        void UpdateEquipment(AdditionalEquipment additionalEquipment);
    }
}