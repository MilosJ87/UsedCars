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
        bool Save();
        void UpdateEquipment(AdditionalEquipment additionalEquipment);
    }
}