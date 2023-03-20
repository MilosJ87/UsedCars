using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCars.Services;
using UsedCars.Repository;
using UsedCars.GenericRepository;

namespace UsedCars.Common.Extensions
{
    public static class ServiceExtensions
    {
       public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalEquipmentService, AdditionalEquipmentService>();
            services.AddScoped<IAdditionalEquipmentRepo, AdditionalEquipmentRepo>();    
            services.AddScoped<IModelRepo, ModelRepo>();
            services.AddScoped<IMakeRepo, MakeRepo>();
            services.AddScoped<IVehicleRepo, VehicleRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return services;
        }
    }
}
