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
    using Moq;
    using UsedCars.Services;
    using Xunit;

    public class GenericRepositoryTests
    {
        private readonly IGenericRepository<Vehicle> _vehicleRepository;
        private readonly UsedCarsContext _context;

        public GenericRepositoryTests()
        {
            // Mock the IGenericRepository<Vehicle> object
            var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle>>();

            // Set up the mock to return some test data
            var testData = new  List<Vehicle> {
            new Vehicle { Id = Guid.NewGuid(), Name = "Vehicle 1", CategoryId = Guid.NewGuid(), ModelId = Guid.NewGuid(), MakeId = Guid.NewGuid() },
            new Vehicle { Id = Guid.NewGuid(), Name = "Vehicle 2", CategoryId = Guid.NewGuid(), ModelId = Guid.NewGuid(), MakeId = Guid.NewGuid() },
            new Vehicle { Id = Guid.NewGuid(), Name = "Vehicle 3", CategoryId = Guid.NewGuid(), ModelId = Guid.NewGuid(), MakeId = Guid.NewGuid() }
        }.AsEnumerable();

            vehicleRepositoryMock.Setup( m =>  m.GetAllAsync()).Returns(Task.FromResult(testData));

            // Assign the mock to the private field _vehicleRepository
            _vehicleRepository = vehicleRepositoryMock.Object;

            // Mock the UsedCarsContext object
            var contextOptions = new DbContextOptionsBuilder<UsedCarsContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            var contextMock = new Mock<UsedCarsContext>(contextOptions);

            // Assign the mock to the private field _context
            _context = contextMock.Object;
        }

        [Fact]
        public async Task TestGetAllVehicles()
        {
            // Arrange
           // var vehicleService = new IGenericRepository(_vehicleRepository, _context);

            // Act
            var result = await _vehicleRepository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }
    }


}


