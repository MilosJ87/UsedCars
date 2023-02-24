using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Xml.XPath;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Profiles;

namespace UsedCars.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepo _vehicleRepo;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepo vehicleRepo, IMapper mapper)
        {
            _vehicleRepo = vehicleRepo ?? throw new ArgumentNullException(nameof(vehicleRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehicles()
        {
            var vehiclesFromRepo = await _vehicleRepo.GetAllAsync();
            var vehiclesToReturn = _mapper.Map<IEnumerable<VehicleDto>>(vehiclesFromRepo);
            return vehiclesToReturn;
        }

        public async Task<VehicleDto> GetVehicle(Guid vehicleId)
        {
            var vehicleFromRepo = await _vehicleRepo.GetById(vehicleId);
            var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleFromRepo);
            return vehicleToReturn;
        }

        public async Task<VehicleDto> CreateVehicleAsync(VehicleDto vehicle)
        {
            var vehicleEntity = _mapper.Map<Entities.Vehicle>(vehicle);
            _vehicleRepo.Insert(vehicleEntity);
            _vehicleRepo.Save();

            var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleEntity);

            return vehicleToReturn;
        }

        public async Task<VehicleDto> UpdateVehicle(VehicleDto vehicle)
        {
            if (!_vehicleRepo.VehicleExists(vehicle.Id))
            {
                return null;
            }

            var vehicleFromRepo = await _vehicleRepo.GetById(vehicle.Id);

            if (vehicleFromRepo == null)
            {
                var vehicleToAdd = _mapper.Map<Vehicle>(vehicle);
                vehicleToAdd.Id = vehicle.Id;

                _vehicleRepo.Insert(vehicleToAdd);

                _vehicleRepo.Save();

                var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

                return vehicleToReturn;

            }
            _mapper.Map(vehicle, vehicleFromRepo);

            _vehicleRepo.Update(vehicleFromRepo);

            _vehicleRepo.Save();

            var vehiclToReturn = _mapper.Map<VehicleDto>(vehicleFromRepo);

            return vehiclToReturn;

        }

        public async Task<VehicleDto> PatchVehicle(Guid vehicleId, JsonPatchDocument<VehicleDto> patchDocument)
        {
            if (!_vehicleRepo.VehicleExists(vehicleId))
            {
                return null;
            }

            var vehicleFromRepo = await _vehicleRepo.GetById(vehicleId);

            if (vehicleFromRepo == null)
            {
                var vehicleDto = new VehicleDto();
                patchDocument.ApplyTo(vehicleDto);

               

                var vehicleToAdd = _mapper.Map<Vehicle>(vehicleDto);
                vehicleToAdd.Id = vehicleId;

                _vehicleRepo.Insert(vehicleToAdd);

                 _vehicleRepo.Save();

                var vehicleToReturn = _mapper.Map<VehicleDto>(vehicleToAdd);

                return vehicleToReturn;
            }

            var vehicleToPatch = _mapper.Map<VehicleDto>(vehicleFromRepo);

            patchDocument.ApplyTo(vehicleToPatch);

         

            _mapper.Map(vehicleToPatch, vehicleFromRepo);

            _vehicleRepo.Update(vehicleFromRepo);

             _vehicleRepo.Save();

            var updatedVehicle = await _vehicleRepo.GetById(vehicleId);
            var updatedVehicleDto = _mapper.Map<VehicleDto>(updatedVehicle);

            return updatedVehicleDto;
        }

        public async Task DeleteVehicle(Guid vehicleId)
        {
            var vehicleFromRepo = await _vehicleRepo.GetById(vehicleId);

           await _vehicleRepo.Delete(vehicleFromRepo);
            _vehicleRepo.Save();
        }
    }
}
