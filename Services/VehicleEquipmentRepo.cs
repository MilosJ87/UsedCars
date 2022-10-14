using AutoMapper;
using Microsoft.Exchange.WebServices.Data;
using System.Data.Entity;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.Models;

namespace UsedCars.Services
{
    public class VehicleEquipmentRepo
    {
        private readonly UsedCarsContext _usedCarsContext;
        
        public VehicleEquipmentRepo(UsedCarsContext usedCarsContext )
        {
            _usedCarsContext = usedCarsContext;
        }
        

        //public async Task<ServiceResponse<VehicleDto>> AddVehicleEquipment(VehicleEquipmentDto vehicleEquipmentDto)
        //{
        //    ServiceResponse<VehicleDto> response = new ServiceResponse<VehicleDto>();
        //    try
        //    {
        //        Vehicle vehicle = await _usedCarsContext.Vehicles
        //            .Include(c=>c.Name)
        //            .Include(c=>c.AdditionalEquipments)
        //            .FirstOrDefaultAsync();
        //    }
        }
    }

