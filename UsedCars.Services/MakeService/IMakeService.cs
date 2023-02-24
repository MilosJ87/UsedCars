using UsedCars.Models;

namespace UsedCars.Services
{
    public interface IMakeService
    {
        Task<MakeDto> CreateMake(MakeDto makeDto);
        Task DeleteMake(Guid makeId);
        Task<MakeDto> GetMake(Guid makeId);
        Task<IEnumerable<MakeDto>> GetMakes();
    }
}