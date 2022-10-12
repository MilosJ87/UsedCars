using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        public void AddVehicle(Guid categoryId, Guid modelId, Guid makeId,Vehicle vehicle)
        {

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

            _usedCarsContext.Vehicles.Add(vehicle);

        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _usedCarsContext.Vehicles.OrderBy(c => c.Id).ToList();
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

        public Vehicle GetVehicle(Guid categoryId, Guid modelId, Guid makeId, Guid vehicleId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }
            if (makeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(makeId));
            }

            if (modelId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(modelId));
            }

            return _usedCarsContext.Vehicles.Where(c => c.CategoryId == categoryId && c.MakeId == makeId && c.ModelId == modelId && c.Id == vehicleId).FirstOrDefault();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {

        }

        public bool Save()
        {
            return (_usedCarsContext.SaveChanges() >= 0);
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
