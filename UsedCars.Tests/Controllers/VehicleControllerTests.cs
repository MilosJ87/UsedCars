using FakeItEasy;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCars.Controllers;
using UsedCars.Services;

namespace UsedCars.Tests.Controllers
{
    public class VehicleControllerTests
    {
       private readonly IVehicleService _vehicleService;
       public VehicleControllerTests()
        {
            _vehicleService = A.Fake<IVehicleService>();

        }
               
        [Fact]
       public async Task VehicleController_GetVehicle_ReturnOk()
        {
           // var vehicleService = new Mock<IVehicleService>();

           var controller = new VehicleController(_vehicleService);

            var result = await controller.GetVehicleAsync(Guid.Parse("3FA85F64-5717-4562-B3FC-2B963F66AFA6"));

            Assert.NotNull(result);
                     
        }

    }
}
