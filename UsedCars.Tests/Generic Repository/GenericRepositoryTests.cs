using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;

namespace UsedCars.Tests.Generic_Repository
{
    public class GenericRepositoryTests
    {
        private readonly IGenericRepository<Vehicle> _vehicleRepository;
        private readonly UsedCarsContext _context;

        public GenericRepositoryTests(IGenericRepository<Vehicle> vehicleRepository)
        {
            var options = new DbContextOptionsBuilder<UsedCarsContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _context = new UsedCarsContext(options);
            _vehicleRepository = vehicleRepository;
        }

        [Fact]
        public async Task GetAllAsync_Returns_All_Entities()
        {
            // Arrange
            var entities = new List<Vehicle> {
            new Vehicle { Id = Guid.NewGuid(), Name = "Vehicle 1", CategoryId = Guid.NewGuid(), ModelId = Guid.NewGuid(), MakeId = Guid.NewGuid() },
            new Vehicle { Id = Guid.NewGuid(), Name = "Vehicle 2", CategoryId = Guid.NewGuid(), ModelId = Guid.NewGuid(), MakeId = Guid.NewGuid() },
            new Vehicle { Id = Guid.NewGuid(), Name = "Vehicle 3", CategoryId = Guid.NewGuid(), ModelId = Guid.NewGuid(), MakeId = Guid.NewGuid() }
            };

            foreach (var entity in entities)
            {
                await _vehicleRepository.InsertAsync(entity);
            }

            // Act
            var result = await _vehicleRepository.GetAllAsync();

            // Assert
            Assert.Equal(entities.Count, result.Count());
        }
        
    }
}

