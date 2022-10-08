using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Runtime.InteropServices;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Entities.Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Entities.Vehicle>();
        }
    }
}
