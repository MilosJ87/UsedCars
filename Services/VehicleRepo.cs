using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.Models;

namespace UsedCars.Services
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly UsedCarsContext _usedCarsContext;

        public VehicleRepo(UsedCarsContext usedCarsContext)
        {
            _usedCarsContext = usedCarsContext;
        }

        public void AddVehicle(Guid makeId, Guid categoryId, Guid modelId, Vehicle vehicle)
        {

            if (makeId == Guid.Empty)
            {
                throw new ArgumentException(nameof(makeId));
            }
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentException(nameof(categoryId));
            }


            vehicle.ModelId = modelId;
            vehicle.MakeId = makeId;
            vehicle.CategoryId = categoryId;

            _usedCarsContext.Vehicles.Add(vehicle);

        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _usedCarsContext.Vehicles.OrderBy(c => c.Id).ToList();
        }

        public bool categoryExists(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _usedCarsContext.Vehicles.Any(c => c.Id == categoryId);
        }

        public bool Save()
        {
            return (_usedCarsContext.SaveChanges() >= 0);
        }
    }
}
