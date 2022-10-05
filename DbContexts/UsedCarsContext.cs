using Microsoft.EntityFrameworkCore;
using UsedCars.Entities;
using Type = UsedCars.Entities.Type;

namespace UsedCars.DbContexts
{
    public class UsedCarsContext : DbContext
    {
        public UsedCarsContext(DbContextOptions<UsedCarsContext> options)
            :base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Marke> Markes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Type> Types { get; set; }


        public DbSet<AdditionalEquipment> AdditionalEquipments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            base.OnModelCreating(modelBuilder);


        }
    }

    
}
