using AutoMapper;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<Entities.Make, MakeDto>();
            CreateMap<MakeDto, Entities.Make>();
            CreateMap<UpdateMakeDto, Entities.Make>();
        }
    }
}
