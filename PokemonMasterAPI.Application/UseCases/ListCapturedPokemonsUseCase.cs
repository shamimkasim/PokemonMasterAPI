using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Application.UseCases
{
    public class ListCapturedPokemonsUseCase
    {
        private readonly TrainerService _trainerService;

        public ListCapturedPokemonsUseCase(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public List<Pokemon> GetCapturedPokemons(int trainerId)
        {           
            List<Pokemon> capturedPokemons = new List<Pokemon>();
            return capturedPokemons;
        }
    }
}
