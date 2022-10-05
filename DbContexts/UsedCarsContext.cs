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

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Type> Types { get; set; }


        public DbSet<AdditionalEquipment> AdditionalEquipments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Auto"

                });
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                { Id = Guid.Parse("3535afcd-d127-465f-bd18-3159eae20008" ),
                  Name="Audi",
                  VehicleId= Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")

                });
            modelBuilder.Entity<Type>().HasData(
                new Type
                {
                    Id = Guid.Parse("d7bff014-7082-4545-bae9-d86b813e55ad"),
                    Name = "Passenger Car",
                    VehicleId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                }
                );
            modelBuilder.Entity<Model>().HasData(
                new Model
                {
                    Id = Guid.Parse("9be362f3-3d92-4aa0-9417-529c1d9edcac"),
                    Name = "S3",
                    VehicleId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                }
                );
            modelBuilder.Entity<AdditionalEquipment>().HasData(
                new AdditionalEquipment
                {
                    Id = Guid.Parse("18a56916-1766-48f9-a0fe-3c278cb32b69"),
                    Name = "ABS"
                   

                }
                );






            base.OnModelCreating(modelBuilder);


        }
    }

    
}
