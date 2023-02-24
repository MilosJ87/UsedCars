using Microsoft.AspNetCore.JsonPatch;
using UsedCars.Models;

namespace UsedCars.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<VehicleDto> CreateVehicleAsync(VehicleDto vehicle);
        Task DeleteVehicle(Guid vehicleId);
        Task<IEnumerable<VehicleDto>> GetAllVehicles();
        Task<VehicleDto> GetVehicle(Guid vehicleId);
        Task<VehicleDto> PatchVehicle(Guid vehicleId, JsonPatchDocument<VehicleDto> patchDocument);
        Task<VehicleDto> UpdateVehicle(VehicleDto vehicle);
    }
}