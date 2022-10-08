using AutoMapper;
using System.Runtime.InteropServices;
using UsedCars.Models;

namespace UsedCars.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, CategoryDto > ();
            CreateMap<CategoryDto, Entities.Category>();
        }
        
    }
}
