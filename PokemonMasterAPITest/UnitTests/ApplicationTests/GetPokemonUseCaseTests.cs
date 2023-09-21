using Moq;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokemonMasterAPITest.UnitTests.ApplicationTests
{
    public class GetPokemonUseCaseTests
    {
        [Fact]
        public void GetPokemon_ValidId_ReturnsPokemon()
        {
            // Arrange
            int validPokemonId = 1;
            var mockPokemonService = new Mock<PokemonService>();
            mockPokemonService.Setup(service => service.GetPokemonById(validPokemonId)).Returns(new Pokemon { Id = validPokemonId, Name = "Bulbasaur" });
            var getPokemonUseCase = new GetPokemonUseCase(mockPokemonService.Object);

            // Act
            Pokemon resultPokemon = getPokemonUseCase.GetPokemon(validPokemonId);

            // Assert
            Assert.NotNull(resultPokemon);
            Assert.Equal(validPokemonId, resultPokemon.Id);
            Assert.Equal("Bulbasaur", resultPokemon.Name);
        }

        [Fact]
        public void GetPokemon_InvalidId_ReturnsNull()
        {
            // Arrange
            int invalidPokemonId = -1;
            var mockPokemonService = new Mock<PokemonService>();
            mockPokemonService.Setup(service => service.GetPokemonById(invalidPokemonId)).Returns((Pokemon)null);
            var getPokemonUseCase = new GetPokemonUseCase(mockPokemonService.Object);

            // Act
            Pokemon resultPokemon = getPokemonUseCase.GetPokemon(invalidPokemonId);

            // Assert
            Assert.Null(resultPokemon);
        }
    }
}