using UsedCars.Entities;
using UsedCars.Models;

namespace UsedCars.Services
{
    public interface IModelService
    {
        Task<MakeDto> CreateModel(MakeDto modelDto);
        Task DeleteModel(Guid modelId);
        Task<MakeDto> GetModel(Guid modelId);
        Task<IEnumerable<MakeDto>> GetModels();
       
    }
}