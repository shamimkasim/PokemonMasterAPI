using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Application.UseCases
{
    public class ListCapturedPokemonsUseCase: IListCapturedPokemonsUseCase
    {
        private readonly TrainerService _trainerService;

        public ListCapturedPokemonsUseCase(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public List<Pokemon> GetCapturedPokemons(int trainerId)
        {            
            return _trainerService.GetCapturedPokemons(trainerId);
        }
        
    }
}
