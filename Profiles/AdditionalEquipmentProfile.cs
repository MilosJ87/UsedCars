using AutoMapper;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class AdditionalEquipmentProfile : Profile
    {
        public AdditionalEquipmentProfile()
        {
            CreateMap<Entities.AdditionalEquipment, AdditionalEquipmentDto>();
            CreateMap<AdditionalEquipmentDto, Entities.AdditionalEquipment>();
            CreateMap<UpdateAdditionalEquipment,Entities.AdditionalEquipment>();
            CreateMap<Entities.AdditionalEquipment, UpdateAdditionalEquipment>();
        }
    }
}
