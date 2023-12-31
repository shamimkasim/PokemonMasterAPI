using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Application.UseCases
{
    public class GetPokemonUseCase: IGetPokemonUseCase
    {
        private readonly PokemonService _pokemonService;

        public GetPokemonUseCase(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        public Pokemon GetPokemon(int id)
        {           
            return _pokemonService.GetPokemonById(id);
        }
    }
}
