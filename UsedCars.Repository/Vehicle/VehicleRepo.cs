using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public class VehicleRepo : GenericRepository<Entities.Vehicle>, IVehicleRepo
    {
        public VehicleRepo(UsedCarsContext context) : base(context)
        {
        }

        //public async Task AddVehicleAsync(Guid categoryId, Guid modelId, Guid makeId, Guid additionalEquipmentId, Vehicle vehicle)
        //{
        //    var vehicleEquipmentEntity = _usedCarsContext.AdditionalEquipments.
        //        Where(a => a.Id == additionalEquipmentId).FirstOrDefault();

        //    var vehicleEquipment = new VehicleEquipment()
        //    {
        //        AdditionalEquipment = vehicleEquipmentEntity,
        //        Vehicle = vehicle
        //    };

        //    if (makeId == Guid.Empty)
        //    {
        //        throw new ArgumentException(nameof(makeId));
        //    }
        //    if (categoryId == Guid.Empty)
        //    {
        //        throw new ArgumentException(nameof(categoryId));
        //    }
        //    vehicle.CategoryId = categoryId;
        //    vehicle.ModelId = modelId;
        //    vehicle.MakeId = makeId;

        //    await _usedCarsContext.AddAsync(vehicleEquipment);

        //    await _usedCarsContext.Vehicles.AddAsync(vehicle);

        //}
        //public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        //{
        //    var vehicles = await _usedCarsContext.Vehicles.ToListAsync();
        //    return vehicles;
        //}
        public bool VehicleExists(Guid vehicleId)
        {
            if (vehicleId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(vehicleId));
            }

            return _context.Vehicles.Any(c => c.Id == vehicleId);
        }
        
    }
}
