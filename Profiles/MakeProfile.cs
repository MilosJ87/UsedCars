using AutoMapper;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<Entities.Make, MakeDto>().ReverseMap();
            CreateMap<UpdateMakeDto, Entities.Make>();
        }
    }
}
