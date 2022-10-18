using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using UsedCars.DbContexts;
using UsedCars.Entities;

namespace UsedCars.Services
{
    public class AdditionalEquipmentRepo : IDisposable, IAdditionalEquipmentRepo
    {
        private readonly UsedCarsContext _usedCarsContext;
        public AdditionalEquipmentRepo(UsedCarsContext usedCarsContext)
        {
            _usedCarsContext = usedCarsContext;
        }
        public bool AdditionalEquipmentExists(Guid id)
        {
            return _usedCarsContext.AdditionalEquipments.Any(x => x.Id == id);
        }
        public ICollection<AdditionalEquipment> GetAdditionalEquipments()
        {
            return _usedCarsContext.AdditionalEquipments.ToList();
        }
        public ICollection<AdditionalEquipment> GetEquipmentByVehicle(Guid vehicleId)
        {
            return _usedCarsContext.VehicleEquipments.Where(p => p.Vehicle.Id == vehicleId).Select(o => o.AdditionalEquipment).ToList();
        }
        public bool CreateVehicleForEquipment(Guid additionalEquipmentId, Vehicle vehicle)
        {
            var vehicleEquipmentEntity = _usedCarsContext.AdditionalEquipments.Where(a => a.Id == additionalEquipmentId).FirstOrDefault();

            var vehicleEquipment = new VehicleEquipment()
            {
                AdditionalEquipment = vehicleEquipmentEntity,
                Vehicle = vehicle

            };

            _usedCarsContext.Add(vehicleEquipment);
            _usedCarsContext.Add(vehicle);

            return Save();
        }
        public ICollection<Vehicle> GetVehicleByEquipment(Guid additionalEquipmentId)
        {
            return _usedCarsContext.VehicleEquipments.Where(p => p.AdditionalEquipment.Id == additionalEquipmentId).Select(c => c.Vehicle).ToList();
        }
        public AdditionalEquipment GetAdditionalEquipment(Guid id)
        {
            return _usedCarsContext.AdditionalEquipments.Where(e => e.Id == id).FirstOrDefault();
        }
        public bool CreateAdditionalEquipment(AdditionalEquipment additionalEquipment)
        {
            _usedCarsContext.Add(additionalEquipment);
            return Save();
        }
        public void UpdateEquipment(AdditionalEquipment additionalEquipment)
        {

        }
        public bool DeleteEquipment(AdditionalEquipment additionalEquipment)
        {
            _usedCarsContext.Remove(additionalEquipment);
            return Save();
        }
        public bool Save()
        {
            var saved = _usedCarsContext.SaveChanges();
            return saved > 0 ? true : false;
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
