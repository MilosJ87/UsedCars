using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Runtime.InteropServices;
using UsedCars.Entities;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Entities.Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Entities.VehicleEquipment, VehicleEquipmentDto>().ReverseMap();
            CreateMap<Entities.Model, MakeDto>().ReverseMap();
            CreateMap<Entities.Make, MakeDto>().ReverseMap();
            CreateMap<UpdateMakeDto, Entities.Make>();
            CreateMap<Entities.Category, CategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Entities.AdditionalEquipment, AdditionalEquipmentDto>().ReverseMap();
            CreateMap<Entities.AdditionalEquipment, UpdateAdditionalEquipment>().ReverseMap();
        }

    }
}
