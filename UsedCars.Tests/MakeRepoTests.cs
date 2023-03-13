using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using UsedCars.DbContexts;
using UsedCars.Entities;
using UsedCars.GenericRepository;
using UsedCars.Repository;
using Xunit;

namespace UsedCars.Tests
{
    public class MakeRepoTests : IDisposable
    {
        private readonly UsedCarsContext _context;
        private readonly IMakeRepo _makeRepo;

        public MakeRepoTests()
        {
            // Set up an in-memory database for testing
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<UsedCarsContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .UseInternalServiceProvider(serviceProvider)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _context = new UsedCarsContext(options);

            // Seed some test data into the in-memory database
            var makes = new List<Make>
            {
                new Make { Id = Guid.NewGuid(), Name = "Toyota" },
                new Make { Id = Guid.NewGuid(), Name = "Honda" },
                new Make { Id = Guid.NewGuid(), Name = "Ford" },
            };

            _context.Makes.AddRange(makes);
            _context.SaveChanges();

            // Instantiate the MakeRepo object using the in-memory database context
            _makeRepo = new MakeRepo(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public async Task GetAll_ReturnsAllMakes()
        {
            // Act
            var result = await _makeRepo.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetById_ReturnsCorrectMake()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _makeRepo.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public void MakeExists_WithExistingMake_ReturnsTrue()
        {
            // Arrange
            var id =  Guid.NewGuid();

            // Act
            var result = _makeRepo.Exsits(id);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void MakeExists_WithNonExistingMake_ReturnsFalse()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = _makeRepo.Exsits(id);

            // Assert
            Assert.False(result);
        }
    }
}
