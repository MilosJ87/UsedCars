using UsedCars.Models;

namespace UsedCars.API.Services
{
    public interface IAdditionalEquip
    {
        Task<bool> ArticleInInventory();
        Task<IEnumerable<AdditionalEquipmentDto>> GetAdditionalEquipment();
    }
}