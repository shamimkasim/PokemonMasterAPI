using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Infrastructure.ExternalServices.Interfaces;
using PokemonMasterAPI.Presentation.Controllers;
using System.Net;
using Xunit;

namespace PokemonMasterAPI.Tests.Controllers
{
    public class PokemonControllerTests
    {
        [Fact]
        public async Task GetPokemonList_ReturnsOkResult()
        {
            // Arrange
            var mockGetRandomPokemonsUseCase = new Mock<IGetRandomPokemonsUseCase>();
            var mockGetPokemonUseCase = new Mock<IGetPokemonUseCase>();
            var mockCapturePokemonUseCase = new Mock<ICapturePokemonUseCase>();
            var mockListCapturedPokemonsUseCase = new Mock<IListCapturedPokemonsUseCase>();
            var mockPokeApiService = new Mock<IPokeApiService>();


            var controller = new PokemonController(
                mockGetRandomPokemonsUseCase.Object,
                mockGetPokemonUseCase.Object,
                mockCapturePokemonUseCase.Object,
                mockListCapturedPokemonsUseCase.Object,
                mockPokeApiService.Object);

            mockPokeApiService.Setup(service => service.GetPokemons(It.IsAny<int>()))
                             .ReturnsAsync(new List<Pokemon>());

            // Act
            var result = await controller.GetPokemonList(10) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }
    }
}
