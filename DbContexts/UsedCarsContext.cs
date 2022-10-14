using Microsoft.EntityFrameworkCore;
using UsedCars.Entities;
using Category = UsedCars.Entities.Category;

namespace UsedCars.DbContexts
{
    public class UsedCarsContext : DbContext
    {
        public UsedCarsContext(DbContextOptions<UsedCarsContext> options)
            :base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Category> Categories { get; set; }

       // public DbSet<VehicleCategory> vehicleCategories { get; set; }
       public DbSet<VehicleEquipment> VehicleEquipments { get; set; }   

        public DbSet<AdditionalEquipment> AdditionalEquipments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleEquipment>()
                    .HasKey(po => new { po.VehicleId, po.AdditionalEquipmentId });
            modelBuilder.Entity<VehicleEquipment>()
                    .HasOne(p => p.Vehicle)
                    .WithMany(pc => pc.AdditionalEquipments)
                    .HasForeignKey(p => p.VehicleId);
            modelBuilder.Entity<VehicleEquipment>()
                    .HasOne(p => p.AdditionalEquipment)
                    .WithMany(pc => pc.VehicleEquipments)
                    .HasForeignKey(c => c.AdditionalEquipmentId);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id= Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name= "Passenger Car"
                });
            modelBuilder.Entity<Make>().HasData(
                new Make
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Audi"
                });
            modelBuilder.Entity<Model>().HasData(
                new Model
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "S3"
                });


            

            
            base.OnModelCreating(modelBuilder);


        }
    }

    
}
