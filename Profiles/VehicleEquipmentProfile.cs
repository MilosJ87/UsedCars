using UsedCars.Models;
using AutoMapper;
namespace UsedCars.Profiles
{
    public class VehicleEquipmentProfile : Profile
    {
        public VehicleEquipmentProfile()
        {
            CreateMap<Entities.VehicleEquipment, VehicleEquipmentDto>().ReverseMap();
        }
    }
}
