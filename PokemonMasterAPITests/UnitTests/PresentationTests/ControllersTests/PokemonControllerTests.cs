using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Infrastructure.ExternalServices;
using PokemonMasterAPI.Presentation.Controllers;
using Xunit;

namespace PokemonMasterAPI.Tests
{
    public class PokemonControllerTests
    {
        [Fact]
        public void GetPokemon_ReturnsCorrectResponse()
        {
            // Arrange
            var getRandomPokemonsUseCaseMock = new Mock<IGetRandomPokemonsUseCase>();
            var getPokemonUseCaseMock = new Mock<IGetPokemonUseCase>();
            var capturePokemonUseCaseMock = new Mock<ICapturePokemonUseCase>();
            var listCapturedPokemonsUseCaseMock = new Mock<ListCapturedPokemonsUseCase>();
            var pokeApiServiceMock = new Mock<PokeApiService>();

            var controller = new PokemonController(
                getRandomPokemonsUseCaseMock.Object,
                getPokemonUseCaseMock.Object,
                capturePokemonUseCaseMock.Object,
                listCapturedPokemonsUseCaseMock.Object,
                pokeApiServiceMock.Object);

            int offset = 0;
            int limit = 10;

            // Act
            var result = controller.GetPokemon(offset, limit);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<PokemonListResponse>(okResult.Value);

            Assert.Equal(1281, response.Count);
            Assert.Equal($"https://pokeapi.co/api/v2/pokemon?offset={offset + limit}&limit={limit}", response.Next);
            Assert.Null(response.Previous);
            Assert.Equal("bulbasaur", response.Results[0].Name);
        }

        // Add more tests for other endpoints as needed
    }
}
