using AutoMapper;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class AdditionalEquipmentProfile : Profile
    {
        public AdditionalEquipmentProfile()
        {
            CreateMap<Entities.AdditionalEquipment, AdditionalEquipmentDto>().ReverseMap();
            CreateMap<Entities.AdditionalEquipment, UpdateAdditionalEquipment>().ReverseMap();
        }
    }
}
