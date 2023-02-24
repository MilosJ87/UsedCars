using UsedCars.Models;

namespace UsedCars.Services
{
    public interface IAdditionalEquipmentService
    {
        Task<AdditionalEquipmentDto> CreateEquipment(AdditionalEquipmentDto additionalEquipmentDto);
        Task DeleteEquipment(Guid equipmentId);
        Task<AdditionalEquipmentDto> GetEquipment(Guid additionalEquipmentId);
        Task<VehicleDto> GetEquipmentByVehicle(Guid vehicleId);
        Task<IEnumerable<AdditionalEquipmentDto>> GetEquipments();
        Task<AdditionalEquipmentDto> GetVehicleByEquipment(Guid additionalEquipmentId);
    }
}