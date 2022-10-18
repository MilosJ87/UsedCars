using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.Models;

namespace UsedCars.Services
{
    public class VehicleRepo : IDisposable, IVehicleRepo
    {
        private readonly UsedCarsContext _usedCarsContext;

        public VehicleRepo(UsedCarsContext usedCarsContext)
        {
            _usedCarsContext = usedCarsContext;
        }
        public async Task AddVehicleAsync(Guid categoryId, Guid modelId, Guid makeId, Guid additionalEquipmentId, Vehicle vehicle)
        {
            var vehicleEquipmentEntity = _usedCarsContext.AdditionalEquipments.
                Where(a => a.Id == additionalEquipmentId).FirstOrDefault();

            var vehicleEquipment = new VehicleEquipment()
            {
                AdditionalEquipment = vehicleEquipmentEntity,
                Vehicle = vehicle
            };

            if (makeId == Guid.Empty)
            {
                throw new ArgumentException(nameof(makeId));
            }
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentException(nameof(categoryId));
            }
            vehicle.CategoryId = categoryId;
            vehicle.ModelId = modelId;
            vehicle.MakeId = makeId;

            await _usedCarsContext.AddAsync(vehicleEquipment);

            await _usedCarsContext.Vehicles.AddAsync(vehicle);

        }
        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            var vehicles = await _usedCarsContext.Vehicles.ToListAsync();
            return vehicles;
        }
        public bool VehicleExists(Guid vehicleId)
        {
            if (vehicleId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(vehicleId));
            }

            return _usedCarsContext.Vehicles.Any(c => c.Id == vehicleId);
        }
        public void DeleteVehicle(Vehicle vehicle)
        {
            _usedCarsContext.Vehicles.Remove(vehicle);
        }
        public async Task<Vehicle> GetVehicleAsync(Guid vehicleId)
        {

            await _usedCarsContext.Database.ExecuteSqlRawAsync("Waitfor delay'00:00:02';");
            return await _usedCarsContext.Vehicles.FirstOrDefaultAsync();
        }
        public async Task UpdateVehicle(Vehicle vehicle)
        {

        }
        public async Task<bool> Save()
        {
            return (await _usedCarsContext.SaveChangesAsync() >= 0);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}
