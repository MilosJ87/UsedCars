using Microsoft.EntityFrameworkCore;
using UsedCars.Entities;
namespace UsedCars.DbContexts
{
    public class UsedCarsContext : DbContext
    {
        public UsedCarsContext(DbContextOptions<UsedCarsContext> options)
            :base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Fiat"
                },
                new Vehicle()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Porscshe"
                }
                );
             
        }
    }

    
}
