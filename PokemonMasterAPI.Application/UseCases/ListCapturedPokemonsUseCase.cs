using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Application.UseCases
{
    public class ListCapturedPokemonsUseCase: IListCapturedPokemonsUseCase
    {
        private readonly ITrainerService _trainerService;

        public ListCapturedPokemonsUseCase(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public List<Pokemon> GetCapturedPokemons(int trainerId)
        {            
            return _trainerService.GetCapturedPokemons(trainerId);
        }
        
    }
}
