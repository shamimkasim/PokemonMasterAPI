using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Presentation.Controllers;
using Xunit;

namespace PokemonMasterAPI.Tests.Controllers
{
    public class TrainerControllerTests
    {
        [Fact]
        public void RegisterTrainer_Success_ReturnsOkResult()
        {
            // Arrange
            var mockRegisterTrainerUseCase = new Mock<IRegisterTrainerUseCase>();
            var mockTrainerService = new Mock<ITrainerService>();

            var controller = new TrainerController(
                mockRegisterTrainerUseCase.Object,
                mockTrainerService.Object);            
            mockRegisterTrainerUseCase.Setup(useCase => useCase.RegisterTrainer(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()));

            // Act
            var result = controller.RegisterTrainer("John Doe", 30, "123456789");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void RegisterTrainer_Error_ReturnsBadRequestResult()
        {
            // Arrange
            var mockRegisterTrainerUseCase = new Mock<IRegisterTrainerUseCase>();
            var mockTrainerService = new Mock<ITrainerService>();

            var controller = new TrainerController(
                mockRegisterTrainerUseCase.Object,
                mockTrainerService.Object);            
            mockRegisterTrainerUseCase.Setup(useCase => useCase.RegisterTrainer(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
                .Throws(new Exception("Error occurred."));

            // Act
            var result = controller.RegisterTrainer("John Doe", 30, "123456789");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetTrainerById_Success_ReturnsOkResult()
        {
            // Arrange
            var mockRegisterTrainerUseCase = new Mock<IRegisterTrainerUseCase>();
            var mockTrainerService = new Mock<ITrainerService>();

            var controller = new TrainerController(
                mockRegisterTrainerUseCase.Object,
                mockTrainerService.Object);           
            mockTrainerService.Setup(service => service.GetTrainerById(It.IsAny<int>()))
                .Returns(new Trainer { Id = 1, Name = "John Doe", Age = 30, CPF = "123456789" });

            // Act
            var result = controller.GetTrainerById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetTrainerById_Error_ReturnsBadRequestResult()
        {
            // Arrange
            var mockRegisterTrainerUseCase = new Mock<IRegisterTrainerUseCase>();
            var mockTrainerService = new Mock<ITrainerService>();

            var controller = new TrainerController(
                mockRegisterTrainerUseCase.Object,
                mockTrainerService.Object);           
            mockTrainerService.Setup(service => service.GetTrainerById(It.IsAny<int>()))
                .Throws(new Exception("Error occurred."));

            // Act
            var result = controller.GetTrainerById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
