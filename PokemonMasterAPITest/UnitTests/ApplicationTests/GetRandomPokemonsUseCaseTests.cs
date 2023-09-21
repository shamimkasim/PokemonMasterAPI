using Moq;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Infrastructure.Data;
using PokemonMasterAPI.Infrastructure.Data.Repositories;
using Xunit;

namespace PokemonMasterAPITest.UnitTests.ApplicationTests
{
    public class GetRandomPokemonsUseCaseTests
    {
        [Fact]
        public void GetRandomPokemons_WithValidCount_ShouldReturnListOfPokemons()
        {
            // Arrange
            int count = 5;
            List<Pokemon> expectedPokemons = new List<Pokemon>
            {
                new Pokemon { Id = 1, Name = "Bulbasaur" },
                new Pokemon { Id = 2, Name = "Ivysaur" },
                new Pokemon { Id = 3, Name = "Venusaur" },
                new Pokemon { Id = 4, Name = "Charmander" },
                new Pokemon { Id = 5, Name = "Charmeleon" }
            };

            var pokemonRepositoryMock = new Mock<IPokemonRepository>();
            pokemonRepositoryMock.Setup(repo => repo.GetRandomPokemons(count)).Returns(expectedPokemons);

            var getRandomPokemonsUseCase = new GetRandomPokemonsUseCase(pokemonRepositoryMock.Object);

            // Act
            List<Pokemon> actualPokemons = getRandomPokemonsUseCase.GetRandomPokemons(count);

            // Assert
            Assert.Equal(expectedPokemons, actualPokemons);
        }

        [Fact]
        public void GetRandomPokemons_WithInvalidCount_ShouldThrowArgumentException()
        {
            // Arrange
            int count = -5;

            var pokemonRepositoryMock = new Mock<IPokemonRepository>();
            var getRandomPokemonsUseCase = new GetRandomPokemonsUseCase(pokemonRepositoryMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => getRandomPokemonsUseCase.GetRandomPokemons(count));
        }
    }
}