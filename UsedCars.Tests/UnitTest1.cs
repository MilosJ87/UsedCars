using UsedCars.Models;

namespace UsedCars.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Id_ShouldBeSettableAndGettable()
        {
            // Arrange
            var vehicleDto = new VehicleDto();
            var expectedId = Guid.NewGuid();

            // Act
            vehicleDto.Id = expectedId;
            var actualId = vehicleDto.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public void Name_ShouldBeSettableAndGettable()
        {
            // Arrange
            var vehicleDto = new VehicleDto();
            var expectedName = "Honda Civic";

            // Act
            vehicleDto.Name = expectedName;
            var actualName = vehicleDto.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void CategoryId_ShouldBeSettableAndGettable()
        {
            // Arrange
            var vehicleDto = new VehicleDto();
            var expectedCategoryId = Guid.NewGuid();

            // Act
            vehicleDto.CategoryId = expectedCategoryId;
            var actualCategoryId = vehicleDto.CategoryId;

            // Assert
            Assert.Equal(expectedCategoryId, actualCategoryId);
        }

        [Fact]
        public void ModelId_ShouldBeSettableAndGettable()
        {
            // Arrange
            var vehicleDto = new VehicleDto();
            var expectedModelId = Guid.NewGuid();

            // Act
            vehicleDto.ModelId = expectedModelId;
            var actualModelId = vehicleDto.ModelId;

            // Assert
            Assert.Equal(expectedModelId, actualModelId);
        }

        [Fact]
        public void MakeId_ShouldBeSettableAndGettable()
        {
            // Arrange
            var vehicleDto = new VehicleDto();
            var expectedMakeId = Guid.NewGuid();

            // Act
            vehicleDto.MakeId = expectedMakeId;
            var actualMakeId = vehicleDto.MakeId;

            // Assert
            Assert.Equal(expectedMakeId, actualMakeId);
        }

        [Fact]
        public void AdditionalEquipmentDtoList_ShouldBeSettableAndGettable()
        {
            // Arrange
            var vehicleDto = new VehicleDto();
            var expectedAdditionalEquipmentDtoList = new List<AdditionalEquipmentDto>()
            {
                new AdditionalEquipmentDto { Id = Guid.NewGuid(), Name = "Sunroof" },
                new AdditionalEquipmentDto { Id = Guid.NewGuid(), Name = "Leather Seats" }
            };

            // Act
            vehicleDto.AdditionalEquipmentDtoList = expectedAdditionalEquipmentDtoList;
            var actualAdditionalEquipmentDtoList = vehicleDto.AdditionalEquipmentDtoList;

            // Assert
            Assert.Equal(expectedAdditionalEquipmentDtoList, actualAdditionalEquipmentDtoList);
        }
    }
}