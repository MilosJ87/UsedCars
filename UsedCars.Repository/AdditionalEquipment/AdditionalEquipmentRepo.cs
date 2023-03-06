using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public class AdditionalEquipmentRepo : GenericRepository<Entities.AdditionalEquipment>, IAdditionalService
    {
        public AdditionalEquipmentRepo(UsedCarsContext context) : base(context)
        {
        }
        public bool AdditionalEquipmentExists(Guid id)
        {
            return _context.AdditionalEquipments.Any(x => x.Id == id);
        }
        public ICollection<AdditionalEquipment> GetEquipmentByVehicle(Guid vehicleId)
        {
            return  _context.VehicleEquipments.Where(p => p.Vehicle.Id == vehicleId).Select(o => o.AdditionalEquipment).ToList();
        }
        public void CreateVehicleForEquipment(Guid additionalEquipmentId, Vehicle vehicle)
        {
            var vehicleEquipmentEntity = _context.AdditionalEquipments.Where(a => a.Id == additionalEquipmentId).FirstOrDefault();

            var vehicleEquipment = new VehicleEquipment()
            {
                AdditionalEquipment = vehicleEquipmentEntity,
                Vehicle = vehicle

            };

            _context.Add(vehicleEquipment);
            _context.Add(vehicle);
            _context.SaveChanges();


        }
        public ICollection<Vehicle> GetVehicleByEquipment(Guid additionalEquipmentId)
        {
            return  _context.VehicleEquipments.Where(p => p.AdditionalEquipment.Id == additionalEquipmentId).Select(c => c.Vehicle).ToList();
        }
        
    }
}
