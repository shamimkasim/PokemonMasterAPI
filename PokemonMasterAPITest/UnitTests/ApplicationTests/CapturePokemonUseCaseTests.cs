using Moq;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PokemonMasterAPITest.UnitTests.ApplicationTests
{
    public class CapturePokemonUseCaseTests
    {
        [Fact]
        public void CapturePokemon_PositiveScenario()
        {
            // Arrange
            int trainerId = 1;
            int pokemonId = 42;

            var mockTrainerRepository = new Mock<ITrainerRepository>();
            mockTrainerRepository.Setup(repo => repo.GetTrainerById(trainerId)).Returns(new Trainer());

            var mockPokemonRepository = new Mock<IPokemonRepository>();
            mockPokemonRepository.Setup(repo => repo.GetPokemonById(pokemonId)).Returns(new Pokemon());

            var mockContext = new Mock<PokemonDbContext>();

            var useCase = new CapturePokemonUseCase(mockTrainerRepository.Object, mockPokemonRepository.Object, mockContext.Object);

            // Act
            Action captureAction = () => useCase.CapturePokemon(trainerId, pokemonId);

            // Assert
            Assert.Null(Record.Exception(captureAction));
        }

        [Fact]
        public void CapturePokemon_NegativeScenario_InvalidTrainerOrPokemon()
        {
            // Arrange
            int trainerId = 1;
            int pokemonId = 42;

            var mockTrainerRepository = new Mock<ITrainerRepository>();
            mockTrainerRepository.Setup(repo => repo.GetTrainerById(trainerId)).Returns((Trainer)null); // Returning null to simulate invalid trainer

            var mockPokemonRepository = new Mock<IPokemonRepository>();
            mockPokemonRepository.Setup(repo => repo.GetPokemonById(pokemonId)).Returns((Pokemon)null); // Returning null to simulate invalid pokemon

            var mockContext = new Mock<PokemonDbContext>();

            var useCase = new CapturePokemonUseCase(mockTrainerRepository.Object, mockPokemonRepository.Object, mockContext.Object);

            // Act
            Action captureAction = () => useCase.CapturePokemon(trainerId, pokemonId);

            // Assert
            Assert.NotNull(Record.Exception(captureAction));
        }
    }
}