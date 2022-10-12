using AutoMapper;
using UsedCars.Entities;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ModelDto>();
            CreateMap<ModelDto, Model>();
        }
    }
}
