using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository;

namespace UsedCars.Services
{
    public class AdditionalEquipmentService : IAdditionalEquipmentService
    {
        private readonly IAdditionalService _additionalEquipmentRepo;

        private readonly IMapper _mapper;

        public AdditionalEquipmentService(IAdditionalService additionalEquipmentRepo, IMapper mapper)
        {
            _additionalEquipmentRepo = additionalEquipmentRepo ?? throw new ArgumentNullException(nameof(additionalEquipmentRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AdditionalEquipmentDto>> GetEquipments()
        {
            var equipments = await _additionalEquipmentRepo.GetAllAsync();
            var equipmentsToReturn
                = _mapper.Map<IEnumerable<AdditionalEquipmentDto>>(equipments);
            return equipmentsToReturn;
        }

        public async Task<AdditionalEquipmentDto> GetEquipment(Guid additionalEquipmentId)
        {
            var equipments = await _additionalEquipmentRepo.GetById(additionalEquipmentId);
            var equipmentToReturn = _mapper.Map<AdditionalEquipmentDto>(equipments);
            return equipmentToReturn;
        }

        public async Task<AdditionalEquipmentDto> CreateEquipment(AdditionalEquipmentDto additionalEquipmentDto)
        {
            var equipemntToCreate = _mapper.Map<Entities.AdditionalEquipment>(additionalEquipmentDto);
            _additionalEquipmentRepo.Insert(equipemntToCreate);
            _additionalEquipmentRepo.Save();
            var equipmentToReturn = _mapper.Map<AdditionalEquipmentDto>(equipemntToCreate);
            return equipmentToReturn;

        }
       
        public async Task<AdditionalEquipmentDto> GetVehicleByEquipment(Guid additionalEquipmentId)
        {
            var equipment = _additionalEquipmentRepo.GetVehicleByEquipment(additionalEquipmentId).FirstOrDefault();
            var equipmentToReturn = _mapper.Map<AdditionalEquipmentDto>(equipment);

            return equipmentToReturn;
        }

        public async Task<VehicleDto> GetEquipmentByVehicle(Guid vehicleId)
        {
            var vehicle = _additionalEquipmentRepo.GetEquipmentByVehicle(vehicleId);
            var vehicleToReturn = _mapper.Map<VehicleDto>(vehicle);

            return vehicleToReturn;
        }
        public async Task DeleteEquipment(Guid equipmentId)
        {
            var equipmentToDelete = _additionalEquipmentRepo.GetById(equipmentId);
            var deleteEquipment = _additionalEquipmentRepo.Delete(equipmentToDelete);
            _additionalEquipmentRepo.Save();

        }
    }
}
