using Microsoft.EntityFrameworkCore.Diagnostics;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Repository
{
    public class MakeRepo : GenericRepository<Entities.Make>, IMakeRepo
    {
        public MakeRepo(UsedCarsContext context) : base(context)
        {
        }
          
    }
}
